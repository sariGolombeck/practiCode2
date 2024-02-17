using System;
using System.Collections.Generic;
using System.Linq;

namespace HtmlSeriazler1
{
    public class Selector
    {
        public string TagName { get; set; }
        public string Id { get; set; }
        public List<string> Classes { get; set; }
        public Selector Parent { get; set; }
        public Selector Child { get; set; }

        public static Selector ParseSelector(string selectorString)
        {
            // Split the selector string into parts
            string[] parts = selectorString.Split(' ');

            // Initialize the root selector
            Selector rootSelector = new Selector();
            Selector currentSelector = rootSelector;
            foreach (string part in parts)
            {
                // Create a new selector for each part
                Selector newSelector = new Selector();

                // Split the part into tag name, id, and classes
                string[] selectors = part.Split(new char[] { '.', '#' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string sel in selectors)
                {
                    // Check if the selector starts with '#' or '.'
                    if (sel.StartsWith("#"))
                    {
                        newSelector.Id = sel.Substring(1);
                    }
                    else if (sel.StartsWith("."))
                    {
                        if (newSelector.Classes == null)
                        {
                            newSelector.Classes = new List<string>();
                        }
                        newSelector.Classes.Add(sel.Substring(1));
                    }
                    else
                    {
                        // Check if the selector is a valid HTML tag name
                        if (IsValidTagName(sel))
                        {
                            newSelector.TagName = sel;
                        }
                        else
                        {
                          //  throw new ArgumentException("Invalid selector: " + selectorString);
                        }
                    }
                }

                // Set the parent and child relationships
                currentSelector.Child = newSelector;
                newSelector.Parent = currentSelector;

                // Move to the next selector
                currentSelector = newSelector;
            }

            return rootSelector;
        }

        private static bool IsValidTagName(string tagName)
        {
            // Check if the tag name is in the list of HTML tags
            HtmlHelper htmlHelper = HtmlHelper.InstanceHtmlHelper;
            string[] htmlTags = htmlHelper.AllHtmlTags;
            return htmlTags.Contains(tagName);
        }
        public async Task<string> Load(string url)
        {


            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var html = await response.Content.ReadAsStringAsync();
            return html;


        }
    }
}
