// See https://aka.ms/new-console-template for more information



string north  ="north";
string south = "south";

string longMessage = """
    This is a long message.
    It has several lines.
        Some are indented
                more than others.
    Some should start at the first column.
    Some have "quoted text" in them. 
    """;
string shortMessage = $$""" 
{{Environment.NewLine}}Multiple $ characters denote how many consecutive 
braces start and end the interpolation. e.g {{north}} {{{south}}} 
""";
Console.WriteLine(longMessage);
Console.WriteLine(shortMessage);

