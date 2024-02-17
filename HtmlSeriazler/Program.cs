////////using System.Text.RegularExpressions;
////////var html = await Load("https://hebrewbooks.org/beis");
////////var cleanHtml = new Regex("\\s").Replace(html, "");
////////var htmlLines = new Regex("<(.*?)>").Split(cleanHtml).Where(s => s.Length > 0);
////////var htmlElement = "<div id=\"my-id\" class=\"my-class-1 my-class-2\" width=\"100%\">text</div>";
////////var attributes = new Regex("([^\\s]*?)=\"(.*?)\"").Matches(htmlElement);
////////Console.WriteLine();
////////async Task<string> Load(string url)
////////{


////////    HttpClient client = new HttpClient();
////////    var response = await client.GetAsync(url);
////////    var html = await response.Content.ReadAsStringAsync();
////////    return html;


//////////}
//////using HtmlSeriazler1;

//////HtmlParser serializer = new HtmlParser();
//////var html = await Load("https://forum.netfree.link/category/1/%D7%94%D7%9B%D7%A8%D7%96%D7%95%D7%AA");

//////var dom =serializer.ParseHtml(html);
//////var result = dom.FindElementsBySelector(Selector.ParseSelector("ul.nav.navbar-nav"));
//////var x = result.ToString();
////////for (int i = 0; i <x.Length; i++)
////////{
////////    Console.WriteLine(x.);
////////}
//////result.ToList().ForEach(e => Console.WriteLine(e.Name));
//////Console.ReadLine();
//////async Task<string> Load(string url)
//////{


//////    HttpClient client = new HttpClient();
//////    var response = await client.GetAsync(url);
//////    var html = await response.Content.ReadAsStringAsync();
//////    return html;
//////}

////////}
////////using HtmlSeriazler1;
////////using System.Diagnostics;

////////var elements = HtmlElement.Fine("div .class-name");

////////// הדפסת רשימת האלמנטים למסך
////////Console.WriteLine("Matching Elements:");
////////foreach (var element in elements)
////////{
////////    Console.WriteLine($"Element Name: {element.Name}, ID: {element.Id}, Classes: {string.Join(", ", element.Classes)}");
////////}

////////// פתיחת הדפדפן ובדיקה ידנית של רשימת האלמנטים על האתר
////////Process.Start("chrome.exe", "https://example.com");
////////Console.WriteLine("Please verify the elements on the website manually.");

////////Console.ReadLine();
//////using System.Text.RegularExpressions;
//////var html = await Load("https://hebrewbooks.org/beis");
//////var cleanHtml = new Regex("\\s").Replace(html, "");
//////var htmlLines = new Regex("<(.*?)>").Split(cleanHtml).Where(s => s.Length > 0);
//////var htmlElement = "<div id=\"my-id\" class=\"my-class-1 my-class-2\" width=\"100%\">text</div>";
//////var attributes = new Regex("([^\\s]*?)=\"(.*?)\"").Matches(htmlElement);
//////Console.WriteLine();
//////async Task<string> Load(string url)
//////{


//////    HttpClient client = new HttpClient();
//////    var response = await client.GetAsync(url);
//////    var html = await response.Content.ReadAsStringAsync();
//////    return html;


////////}
////using HtmlSeriazler1;

////HtmlParser serializer = new HtmlParser();
////var html = await Load("https://forum.netfree.link/category/1/%D7%94%D7%9B%D7%A8%D7%96%D7%95%D7%AA");

////var dom = serializer.ParseHtml(html);
////var result = dom.FindElementsBySelector(Selector.ParseSelector("ul.nav.navbar-nav"));
////var x = result.ToString();
//////for (int i = 0; i <x.Length; i++)
//////{
//////    Console.WriteLine(x.);
//////}
////result.ToList().ForEach(e => Console.WriteLine(e.Name));
////Console.ReadLine();
////async Task<string> Load(string url)
////{


////    HttpClient client = new HttpClient();
////    var response = await client.GetAsync(url);
////    var html = await response.Content.ReadAsStringAsync();
////    return html;
////}

//////}
//////using HtmlSeriazler1;
//////using System.Diagnostics;

//////var elements = HtmlElement.Fine("div .class-name");

//////// הדפסת רשימת האלמנטים למסך
//////Console.WriteLine("Matching Elements:");
//////foreach (var element in elements)
//////{
//////    Console.WriteLine($"Element Name: {element.Name}, ID: {element.Id}, Classes: {string.Join(", ", element.Classes)}");
//////}

//////// פתיחת הדפדפן ובדיקה ידנית של רשימת האלמנטים על האתר
//////Process.Start("chrome.exe", "https://example.com");
//////Console.WriteLine("Please verify the elements on the website manually.");

//////Console.ReadLine();

////using htmlSerializer;
//using HtmlSeriazler1;
//using System.Text.RegularExpressions;

//var html = await Load("https://hebrewbooks.org/beis");

//HtmlElement htmlElement1 = new HtmlElement();
//HtmlParser parser = new HtmlParser();
//htmlElement1 = parser.Serialize(html);
//Console.WriteLine("----Serialize----");

//Selector selector = new Selector();
//selector = Selector.ParseSelector("div p.class-name.claas-sari&ruthy");
//Console.WriteLine("-----selector-----");

//IEnumerable<HtmlElement> l = htmlElement1.Descendants();
//Console.WriteLine("----Descendants----");

//IEnumerable<HtmlElement> l1 = htmlElement1.Ancestors();//מכיון שהפונקציה עובדת עם yeild והפונקציה לא שומשה לאף אחד אז מיד עברה להדפסה
//Console.WriteLine("----Ancestors----");


////selector:
//string queryString1 = "#pnlMenubar table div.inactBG";//5 results
//string queryString2 = "div tr.oddrow td a";//1866 results
//string queryString3 = "tr td div#cpMstr_PanelSeforim";//only one result
//selector = Selector.ParseSelector(queryString1);
//var elementsList = htmlElement1.FindElementsBySelector(selector);
//Console.WriteLine("----FindElementsBySelector----");



//static async Task<string> Load(string url)
//{
//    HttpClient client = new HttpClient();
//    var response = await client.GetAsync(url);
//    var html = await response.Content.ReadAsStringAsync();
//    return html;
//}using HtmlSerializer;

using HtmlSeriazler1;

static void PrintHtmlTree(HtmlElement element, string indent = "")
{
    Console.Write($"{indent}<{element.Name}");
    Console.WriteLine(">");

    if (element.Children.Any())
    {
        foreach (var child in element.Children)
        {
            PrintHtmlTree(child, indent + "  ");
        }
    }
  
}
static void PrintHtmlElement(HtmlElement element, string indent = "")
{
    Console.Write($"{indent}<{element.Name}");
    if (element.Attributes.Any())
    {
        Console.Write($" {string.Join(" ", element.Attributes)}");
    }
    Console.WriteLine($"{indent}</{element.Name}>");
}
static async Task<string> Load(string url)
{
    HttpClient client = new HttpClient();
    var response = await client.GetAsync(url);
    var html = await response.Content.ReadAsStringAsync();
    return html;
}

//loading an html page:
var html = await Load("https://forum.netfree.link/category/1/%D7%94%D7%9B%D7%A8%D7%96%D7%95%D7%AA");
//var cleanHtml = new Regex("\\s+").Replace(html, " ");
//var htmlLines = new Regex("<(.*?)>").Split(cleanHtml).Where(s => s.Length > 0).ToList();

//Build the tree:
HtmlParser tree = new HtmlParser();
var htmlTree = tree.Serialize(html);
    
//queryStrings:
string queryString1 = "a i.fa";//45 results
string queryString2 = "nav#menu.slideout-menu";//only 1 result
string queryString3 = "div .category";//only 1 result

//selector:

var selector = Selector.ParseSelector(queryString2);
var elementsList = htmlTree.FindElementsBySelector(selector);

//Print the elements:
Console.WriteLine("List of " + elementsList.ToList().Count() + " elements found !!");
foreach (var element in elementsList)
{
    Console.WriteLine("My ancestors are:");
    foreach (var father in element.Ancestors().ToList())
    {
        Console.Write("  " + father.Name);
    }
    Console.WriteLine();
    PrintHtmlElement(element);
    Console.WriteLine("--------------------------------------------------------");
}




