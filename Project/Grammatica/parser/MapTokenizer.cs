/*
 * MapTokenizer.cs
 *
 * THIS FILE HAS BEEN GENERATED AUTOMATICALLY. DO NOT EDIT!
 */

using System.IO;

using PerCederberg.Grammatica.Runtime;

/**
 * <remarks>A character stream tokenizer.</remarks>
 */
internal class MapTokenizer : Tokenizer {

    /**
     * <summary>Creates a new tokenizer for the specified input
     * stream.</summary>
     *
     * <param name='input'>the input stream to read</param>
     *
     * <exception cref='ParserCreationException'>if the tokenizer
     * couldn't be initialized correctly</exception>
     */
    public MapTokenizer(TextReader input)
        : base(input, false) {

        CreatePatterns();
    }

    /**
     * <summary>Initializes the tokenizer by creating all the token
     * patterns.</summary>
     *
     * <exception cref='ParserCreationException'>if the tokenizer
     * couldn't be initialized correctly</exception>
     */
    private void CreatePatterns() {
        TokenPattern  pattern;

        pattern = new TokenPattern((int) MapConstants.FOLDER_O,
                                   "FOLDER_O",
                                   TokenPattern.PatternType.STRING,
                                   "FOLDER_O");
        AddPattern(pattern);

        pattern = new TokenPattern((int) MapConstants.FOLDER_C,
                                   "FOLDER_C",
                                   TokenPattern.PatternType.STRING,
                                   "FOLDER_C");
        AddPattern(pattern);

        pattern = new TokenPattern((int) MapConstants.PLACEMARK_O,
                                   "PLACEMARK_O",
                                   TokenPattern.PatternType.STRING,
                                   "PLACEMARK_O");
        AddPattern(pattern);

        pattern = new TokenPattern((int) MapConstants.PLACEMARK_C,
                                   "PLACEMARK_C",
                                   TokenPattern.PatternType.STRING,
                                   "PLACEMARK_C");
        AddPattern(pattern);

        pattern = new TokenPattern((int) MapConstants.TESSELLATE_V,
                                   "TESSELLATE_V",
                                   TokenPattern.PatternType.STRING,
                                   "TESSELLATE_V");
        AddPattern(pattern);

        pattern = new TokenPattern((int) MapConstants.COORDINATES_V,
                                   "COORDINATES_V",
                                   TokenPattern.PatternType.STRING,
                                   "COORDINATES_V");
        AddPattern(pattern);

        pattern = new TokenPattern((int) MapConstants.NAME_V,
                                   "NAME_V",
                                   TokenPattern.PatternType.STRING,
                                   "NAME_V");
        AddPattern(pattern);

        pattern = new TokenPattern((int) MapConstants.DESCRIPTION_V,
                                   "DESCRIPTION_V",
                                   TokenPattern.PatternType.STRING,
                                   "DESCRIPTION_V");
        AddPattern(pattern);

        pattern = new TokenPattern((int) MapConstants.POINT_O,
                                   "POINT_O",
                                   TokenPattern.PatternType.STRING,
                                   "POINT_O");
        AddPattern(pattern);

        pattern = new TokenPattern((int) MapConstants.POINT_C,
                                   "POINT_C",
                                   TokenPattern.PatternType.STRING,
                                   "POINT_C");
        AddPattern(pattern);

        pattern = new TokenPattern((int) MapConstants.LINESTRING_O,
                                   "LINESTRING_O",
                                   TokenPattern.PatternType.STRING,
                                   "LINESTRING_O");
        AddPattern(pattern);

        pattern = new TokenPattern((int) MapConstants.LINESTRING_C,
                                   "LINESTRING_C",
                                   TokenPattern.PatternType.STRING,
                                   "LINESTRING_C");
        AddPattern(pattern);

        pattern = new TokenPattern((int) MapConstants.WHITESPACE,
                                   "WHITESPACE",
                                   TokenPattern.PatternType.REGEXP,
                                   "[ \\t\\n\\r]+");
        pattern.Ignore = true;
        AddPattern(pattern);
    }
}
