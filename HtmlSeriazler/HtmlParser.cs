////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Text.Json;
////using System.Text.RegularExpressions;
////using System.Threading.Tasks;

////namespace HtmlSeriazler1
////{

////    //    public class HtmlParser
////    //    {
////    //        private readonly string[] selfClosingTags;

////    //        public HtmlParser(string selfClosingTagsJsonPath)
////    //        {
////    //            selfClosingTags = LoadSelfClosingTags(selfClosingTagsJsonPath);
////    //        }

////    //        private string[] LoadSelfClosingTags(string jsonFilePath)
////    //        {
////    //            string jsonContent = File.ReadAllText(jsonFilePath);
////    //            return JsonSerializer.Deserialize<string[]>(jsonContent);
////    //        }

////    //        public HtmlElement ParseHtml(string[] htmlStrings)
////    //    {
////    //        var root = new HtmlElement();
////    //        var currentElement = root;

////    //        foreach (var htmlString in htmlStrings)
////    //        {
////    //            var tagMatch = Regex.Match(htmlString, @"^<(\w+)");
////    //            if (tagMatch.Success)
////    //            {
////    //                var tagName = tagMatch.Groups[1].Value;
////    //                if (selfClosingTags.Contains(tagName))
////    //                {
////    //                    var newElement = new HtmlElement { Name = tagName };
////    //                    currentElement.Children.Add(newElement);
////    //                }
////    //                else if (htmlString.EndsWith("/>"))
////    //                {
////    //                    var newElement = new HtmlElement { Name = tagName };
////    //                    currentElement.Children.Add(newElement);
////    //                }
////    //                else if (htmlString.EndsWith("</" + tagName + ">"))
////    //                {
////    //                    currentElement = currentElement.Parent;
////    //                }
////    //                else
////    //                {
////    //                    var newElement = new HtmlElement { Name = tagName, Parent = currentElement };
////    //                    currentElement.Children.Add(newElement);
////    //                    currentElement = newElement;
////    //                }
////    //            }
////    //            else
////    //            {
////    //                currentElement.InnerHtml = htmlString;
////    //            }
////    //        }

////    //        return root;
////    //    }
////    //}

////    public class HtmlParser
////    {
////      static readonly  HtmlHelper htmlHelper = HtmlHelper.InstanceHtmlHelper;
////        //private readonly string[] selfClosingTags;
////        //private readonly string[] allTags;

////        //public HtmlParser(string allTagsJsonPath, string selfClosingTagsJsonPath)
////        //{
////        //    allTags = LoadTagsFromFile(allTagsJsonPath);
////        //    selfClosingTags = LoadTagsFromFile(selfClosingTagsJsonPath);
////        //}

////        //private string[] LoadTagsFromFile(string jsonFilePath)
////        //{
////        //    string jsonContent = File.ReadAllText(jsonFilePath);
////        //    return JsonSerializer.Deserialize<string[]>(jsonContent);
////        //}

////        public HtmlElement ParseHtml(string[] htmlStrings)
////        {
////            var root = new HtmlElement();
////            var currentElement = root;

////            foreach (var htmlString in htmlStrings)
////            {
////                var tagMatch = Regex.Match(htmlString, @"^<(\w+)");
////                if (tagMatch.Success)
////                {
////                    var tagName = tagMatch.Groups[1].Value;
////                    if (htmlHelper.AllHtmlTags.Contains(tagName))
////                    {
////                        var newElement = new HtmlElement { Name = tagName };
////                        currentElement.Children.Add(newElement);
////                    }
////                    else if (htmlString.EndsWith("/>"))
////                    {
////                        var newElement = new HtmlElement { Name = tagName };
////                        currentElement.Children.Add(newElement);
////                    }
////                    else if (htmlString.EndsWith("</" + tagName + ">"))
////                    {
////                        currentElement = currentElement.Parent;
////                    }
////                    else
////                    {
////                        var newElement = new HtmlElement { Name = tagName, Parent = currentElement };
////                        currentElement.Children.Add(newElement);
////                        currentElement = newElement;
////                    }
////                }
////                else
////                {
////                    currentElement.InnerHtml = htmlString;
////                }
////            }

////            return root;
////        }
////    }


////}
//using System;
//using System.Linq;
//using System.Text.RegularExpressions;

//namespace HtmlSeriazler1
//{
//    public class HtmlParser
//    {
//        private readonly HtmlHelper _htmlHelper;

//        public HtmlParser(HtmlHelper htmlHelper)
//        {
//            _htmlHelper = htmlHelper;
//        }

//        public HtmlElement ParseHtml(string htmlString)
//        {
//            HtmlElement rootElement = new HtmlElement();
//            HtmlElement currentElement = rootElement;

//            string[] htmlTags = _htmlHelper.AllHtmlTags;
//            string[] selfClosingTags = _htmlHelper.SelfClosingHtmlTags;

//            foreach (string token in htmlString.Split('<', StringSplitOptions.RemoveEmptyEntries))
//            {
//                string trimmedToken = token.Trim();

//                if (trimmedToken.StartsWith("/html"))
//                {
//                    // Reached end of HTML
//                    break;
//                }

//                string tagName = trimmedToken.Split(new char[] { ' ', '>' }, StringSplitOptions.RemoveEmptyEntries).First();

//                if (tagName.StartsWith("/"))
//                {
//                    // Closing tag, move up one level
//                    currentElement = currentElement.Parent;
//                }
//                else
//                {
//                    HtmlElement newElement = new HtmlElement();
//                    newElement.Name = tagName;

//                    // Check if self-closing tag
//                    if (trimmedToken.EndsWith("/") || selfClosingTags.Contains(tagName))
//                    {
//                        currentElement.Children.Add(newElement);
//                    }
//                    else
//                    {
//                        // Not self-closing, need to add as child
//                        currentElement.Children.Add(newElement);
//                        newElement.Parent = currentElement;
//                        currentElement = newElement;
//                    }

//                    // Parse attributes
//                    MatchCollection attributeMatches = Regex.Matches(trimmedToken, @"(\w+)=""([^""]*)""");
//                    foreach (Match match in attributeMatches)
//                    {
//                        string attributeName = match.Groups[1].Value;
//                        string attributeValue = match.Groups[2].Value;

//                        if (attributeName.ToLower() == "class")
//                        {
//                            newElement.Classes.AddRange(attributeValue.Split(' ', StringSplitOptions.RemoveEmptyEntries));
//                        }
//                        else if (attributeName.ToLower() == "id")
//                        {
//                            newElement.Id = attributeValue;
//                        }
//                        else
//                        {
//                            newElement.Attributes.Add(attributeName + "=" + attributeValue);
//                        }
//                    }
//                }
//            }

//            return rootElement;
//        }
//    }

//}
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HtmlSeriazler1
{
    public class HtmlParser
    {
        //private readonly HtmlHelper _htmlHelper;
        
        private HtmlElement _rootElement;

        public HtmlParser(HtmlHelper htmlHelper)
        {
         //   _htmlHelper = htmlHelper;
        }
        public HtmlParser()
        {

        }
        public HtmlElement Serialize(string html)
        {
            var cleanHtml = new Regex("\\s+").Replace(html, " ");
            var htmlLines = new Regex("<(.*?)>").Split(cleanHtml).Where(s => s.Length > 0).ToList();
            var root = new HtmlElement();
            var currentElement = root;

            foreach (var line in htmlLines)
            {
                var firstWord = line.Split(' ')[0];

                if (firstWord == "/html")
                {
                    break; // Reached end of HTML
                }
                else if (firstWord.StartsWith("/"))
                {
                    if (currentElement.Parent != null) // Make sure there is a valid parent
                    {
                        currentElement = currentElement.Parent; // Go to previous level in the tree
                    }
                }
                else if (HtmlHelper.InstanceHtmlHelper.AllHtmlTags.Contains(firstWord))
                {
                    var newElement = new HtmlElement();
                    newElement.Name = firstWord;

                    // Handle attributes
                    var restOfString = line.Remove(0, firstWord.Length);
                    var attributes = Regex.Matches(restOfString, "([a-zA-Z]+)=\\\"([^\\\"]*)\\\"")
                        .Cast<Match>()
                        .Select(m => $"{m.Groups[1].Value}=\"{m.Groups[2].Value}\"")
                        .ToList();

                    if (attributes.Any(attr => attr.StartsWith("class")))
                    {
                        // Handle class attribute
                        var classAttr = attributes.First(attr => attr.StartsWith("class"));
                        var classes = classAttr.Split('=')[1].Trim('"').Split(' ');
                        newElement.Classes.AddRange(classes);
                    }

                    newElement.Attributes.AddRange(attributes);

                    // Handle ID
                    var idAttribute = attributes.FirstOrDefault(attr => attr.StartsWith("id"));
                    if (!string.IsNullOrEmpty(idAttribute))
                    {
                        newElement.Id = idAttribute.Split('=')[1].Trim('"');
                    }

                    newElement.Parent = currentElement;
                    currentElement.Children.Add(newElement);

                    // Check if self-closing tag
                    if (line.EndsWith("/") || HtmlHelper.InstanceHtmlHelper.SelfClosingHtmlTags.Contains(firstWord))
                    {
                        currentElement = newElement.Parent;
                    }
                    else
                    {
                        currentElement = newElement;
                    }
                }
                else
                {
                    // Text content
                    currentElement.InnerHtml = line;
                }
            }

            return root;
        }
        //public HtmlElement ParseHtml(string htmlString)
        //{
        //    _rootElement = new HtmlElement();
        //    HtmlElement currentElement = _rootElement;
        //    string[] htmlTags = HtmlHelper.InstanceHtmlHelper.AllHtmlTags;
        //    string[] selfClosingTags = HtmlHelper.InstanceHtmlHelper.SelfClosingHtmlTags;


        //    foreach (string token in htmlString.Split('<', StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        string trimmedToken = token.Trim();

        //        if (trimmedToken.StartsWith("/html"))
        //        {
        //            // Reached end of HTML
        //            break;
        //        }
        //        string tagName = trimmedToken.Split(new char[] { ' ', '>' }, StringSplitOptions.RemoveEmptyEntries).First();

        //        if (tagName.StartsWith("/"))
        //        {
        //            // Closing tag, move up one level
        //            currentElement = currentElement.Parent;
        //        }
        //        else
        //        {
        //            HtmlElement newElement = new HtmlElement();
        //            newElement.Name = tagName;

        //            // Check if self-closing tag
        //            if (trimmedToken.EndsWith("/") || selfClosingTags.Contains(tagName))
        //            {
        //                currentElement.Children.Add(newElement);
        //            }
        //            else
        //            {
        //                // Not self-closing, need to add as child
        //                currentElement.Children.Add(newElement);
        //                newElement.Parent = currentElement;
        //                currentElement = newElement;
        //            }

        //            // Parse attributes
        //            MatchCollection attributeMatches = Regex.Matches(trimmedToken, @"(\w+)=""([^""]*)""");
        //            foreach (Match match in attributeMatches)
        //            {
        //                string attributeName = match.Groups[1].Value;
        //                string attributeValue = match.Groups[2].Value;

        //                if (attributeName.ToLower() == "class")
        //                {
        //                    newElement.Classes.AddRange(attributeValue.Split(' ', StringSplitOptions.RemoveEmptyEntries));
        //                }
        //                else if (attributeName.ToLower() == "id")
        //                {
        //                    newElement.Id = attributeValue;
        //                }
        //                else
        //                {
        //                    newElement.Attributes.Add(attributeName + "=" + attributeValue);
        //                }
        //            }
        //        }
        //    }

        //    return _rootElement;
        //}

        public List<HtmlElement> Query(string selector)
        {
            List<HtmlElement> result = new List<HtmlElement>();

            if (_rootElement == null)
            {
                return result;
            }

            // Split the selector into individual parts
            string[] parts = selector.Split(' ');

            // Start querying from the root element
            result = QueryElement(_rootElement, parts[0]);

            // Continue querying based on the remaining parts
            for (int i = 1; i < parts.Length; i++)
            {
                List<HtmlElement> tempResult = new List<HtmlElement>();
                foreach (HtmlElement element in result)
                {
                    tempResult.AddRange(QueryElement(element, parts[i]));
                }
                result = tempResult;
            }

            return result;
        }

        private List<HtmlElement> QueryElement(HtmlElement element, string selector)
        {
            List<HtmlElement> result = new List<HtmlElement>();

            if (selector.StartsWith("#"))
            {
                // Query by ID
                string id = selector.Substring(1);
                if (element.Id == id)
                {
                    result.Add(element);
                }
            }
            else if (selector.StartsWith("."))
            {
                // Query by class
                string className = selector.Substring(1);
                if (element.Classes.Contains(className))
                {
                    result.Add(element);
                }
            }
            else
            {
                // Query by tag name
                if (element.Name == selector)
                {
                    result.Add(element);
                }
            }

            // Recursively query children
            foreach (HtmlElement child in element.Children)
            {
                result.AddRange(QueryElement(child, selector));
            }

            return result;
        }
    }
}
//שניה
