
namespace HtmlSeriazler1
{
    using System;
    using System.Collections.Generic;

    public class HtmlElement
    {
        // תכונות
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Attributes { get; set; }
        public List<string> Classes { get; set; }
        public string InnerHtml { get; set; }

        // קשרי הוראה
        public HtmlElement Parent { get; set; }
        public List<HtmlElement> Children { get; set; }

        // קונסטרקטור
        public HtmlElement()
        {
            Attributes = new List<string>();
            Classes = new List<string>();
            Children = new List<HtmlElement>();
        }
        //public IEnumerable<HtmlElement> Descendants()
        //{
        //    Queue<HtmlElement> queue = new Queue<HtmlElement>();
        //    queue.Enqueue(this);

        //    while (queue.Count > 0)
        //    {
        //        HtmlElement current = queue.Dequeue();
        //        yield return current;

        //        foreach (HtmlElement child in current.Children)
        //        {
        //            queue.Enqueue(child);
        //        }
        //    }
        //}
        // פונקציה הממשית את הרעיון של Descendants באמצעות תור ותוכנות באמצעות הצעדים המתוארים
        public IEnumerable<HtmlElement> Descendants()
        {
            Queue<HtmlElement> queue = new Queue<HtmlElement>();
            queue.Enqueue(this);

            while (queue.Count>0)
            {
                HtmlElement current = queue.Dequeue();

                foreach (HtmlElement child in current.Children)
                {
                    queue.Enqueue(child);
                }

                yield return current;
            }
        }

        // פונקציה הממשית את הרעיון של Ancestors באמצעות רקורסיה ואוסף של אבות האלמנט
        public IEnumerable<HtmlElement> Ancestors()
        {
            List<HtmlElement> ancestors = new List<HtmlElement>();

            // הוסף את האבא הנוכחי
            HtmlElement currentAncestor = this.Parent;
            while (currentAncestor != null)
            {
                ancestors.Add(currentAncestor);
                currentAncestor = currentAncestor.Parent;
            }

            return ancestors;
        }
//        public IEnumerable<HtmlElement> FindElementsBySelector(Selector selector)
//{
//    List<HtmlElement> matchingElements = new List<HtmlElement>();

//    // השימוש בפונקציית Descendants כדי לקבל את כל הצאצאים של האלמנט הנוכחי
//    foreach (HtmlElement descendant in this.Descendants())
//    {
//        // בדיקה אם הצאצא עונה על קריטריוני הסלקטור
//        if (IsElementMatchesSelector(descendant, selector))
//        {
//            matchingElements.Add(descendant);
//        }
//    }

//    return matchingElements;
//}
public IEnumerable<HtmlElement> FindElementsBySelector(Selector selector)
{
    HashSet<HtmlElement> matchingElements = new HashSet<HtmlElement>();

    // השתמש בפונקציית Descendants כדי לקבל את כל הצאצאים של האלמנט הנוכחי
    foreach (HtmlElement descendant in Descendants())
    {
        // בדוק אם הצאצא עונה על קריטריוני הסלקטור
        if (IsElementMatchesSelector(descendant, selector))
        {
            matchingElements.Add(descendant);
        }
    }

    return matchingElements;
}

    private bool IsElementMatchesSelector(HtmlElement element, Selector selector)
{
    // בדיקה האם האלמנט עונה על הקריטריונים של הסלקטור
    if (selector.TagName != null && selector.TagName != element.Name)
    {
        return false;
    }

    if (selector.Id != null && selector.Id != element.Id)
    {
        return false;
    }

    if (selector.Classes != null)
    {
        foreach (string className in selector.Classes)
        {
            if (!element.Classes.Contains(className))
            {
                return false;
            }
        }
    }

    return true;
}
      
    }

    }