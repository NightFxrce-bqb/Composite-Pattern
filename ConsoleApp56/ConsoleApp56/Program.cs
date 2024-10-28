
using System;
using System.Collections.Generic;

// 1. Интерфейс IDocumentComponent
public interface IDocumentComponent
{
    void Add(IDocumentComponent component);
    void Remove(IDocumentComponent component);
    void Display(int indent);
}

// 2. Класс Paragraph
public class Paragraph : IDocumentComponent
{
    private string text;

    public Paragraph(string text)
    {
        this.text = text;
    }

    public void Add(IDocumentComponent component)
    {
        throw new NotImplementedException("Paragraph cannot contain other components.");
    }

    public void Remove(IDocumentComponent component)
    {
        throw new NotImplementedException("Paragraph cannot contain other components.");
    }

    public void Display(int indent)
    {
        Console.WriteLine(new string(' ', indent) + text);
    }
}

// 3. Класс Section
public class Section : IDocumentComponent
{
    private string title;
    private List<IDocumentComponent> components = new List<IDocumentComponent>();

    public Section(string title)
    {
        this.title = title;
    }

    public void Add(IDocumentComponent component)
    {
        components.Add(component);
    }

    public void Remove(IDocumentComponent component)
    {
        components.Remove(component);
    }

    public void Display(int indent)
    {
        Console.WriteLine(new string(' ', indent) + title);
        foreach (var component in components)
        {
            component.Display(indent + 2);
        }
    }
}

// 4. Класс Document
public class Document : IDocumentComponent
{
    private List<IDocumentComponent> sections = new List<IDocumentComponent>();

    public void Add(IDocumentComponent component)
    {
        sections.Add(component);
    }

    public void Remove(IDocumentComponent component)
    {
        sections.Remove(component);
    }

    public void Display(int indent)
    {
        Console.WriteLine("Document Structure:");
        foreach (var section in sections)
        {
            section.Display(indent + 2);
        }
    }
}

// Пример использования
class Program
{
    static void Main()
    {
        Document document = new Document();

        Section section1 = new Section("введение");
        section1.Add(new Paragraph("параграф"));
        Section section1_1 = new Section("фон");
        section1_1.Add(new Paragraph("справочная информация"));
        section1.Add(section1_1);
        document.Add(section1);Ы

        Section section2 = new Section("метедология");
        section2.Add(new Paragraph("раздел описывающий метедологию"));
        document.Add(section2);

        document.Display(0);
    }
}
