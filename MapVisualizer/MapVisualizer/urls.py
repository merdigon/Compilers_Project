from django.conf.urls import include, url
from django.contrib import admin
from main_app.views import upload_file

urlpatterns = [
    # Examples:
    # url(r'^$', 'MapVisualizer.views.home', name='home'),
    # url(r'^blog/', include('blog.urls')),

    url(r'^admin/', include(admin.site.urls)),
    url(r'^$', upload_file, name='home'),
]
