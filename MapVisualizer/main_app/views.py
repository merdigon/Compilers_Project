from django.http import HttpResponseRedirect
from django.shortcuts import render
from .forms import UploadFileForm
from suds.client import Client

def upload_file(request):
    js = ''
    errors = ''
    if request.method == 'POST':
        form = UploadFileForm(request.POST, request.FILES)
        if form.is_valid():
            obj = handle_uploaded_file(request.FILES['file'])
            errors = handle_errors(obj)
            if errors == '':
                js = generate_js(obj)
            form = UploadFileForm()
    else:
        form = UploadFileForm()
    return render(request, 'upload.html', {'form': form, 'js': js, 'errors': errors})


def handle_uploaded_file(f):
    whole = ''
    for chunk in f:
        whole += chunk
    client = Client("http://localhost:8733/MapFileReaderService/?wsdl")
    response = client.service.ReadMap(whole)
    return response

def handle_errors(obj):
    if obj.Errors:
        elist = [e.AdditionalInfo + ': ' + e.Value for e in obj.Errors.ReaderError]
        return '\n'.join(elist)
    else:
        return ''

def generate_js(obj):
    if obj.KmlObject:
        points = [placemark for placemark in obj.KmlObject.Folder.Placemark.PlacemarkKML if placemark.Point]
        lines = [placemark for placemark in obj.KmlObject.Folder.Placemark.PlacemarkKML if placemark.LineString]
        return generate_js_for_points(points) + generate_js_for_lines(lines)

def generate_js_for_points(points):
    generated = ''
    for point in points:
        coords = point.Point.Coordinate.split(',')
        generated += r"""
        new google.maps.Marker({
          position: {lat:"""+ coords[0]+""", lng:""" +coords[1]+"""},
          map: map,
          title: '"""+point.Name+"""'
        }).addListener('click', function() {
          new google.maps.InfoWindow({
          content: '"""+point.Description+"""'
        }).open(map, this);
        });
        """
    return generated

def generate_js_for_lines(lines):
    generated = ''
    for line in lines:
        path = ''
        coords = line.LineString.Coordinates.split(';')
        for coord in coords:
            splited = coord.split(',')
            try:
                path += '{lng: ' + splited[0]+ ', lat: ' + splited[1]+ '},'
            except IndexError:
                pass
        generated += r"""
        new google.maps.Polyline({
        path: ["""+path+"""],
        geodesic: true,
        title: '"""+line.Name+"""',
        strokeColor: '#FF0000',
        strokeOpacity: 1.0,
        strokeWeight: 2
      }).setMap(map);
        """
    return generated

    
