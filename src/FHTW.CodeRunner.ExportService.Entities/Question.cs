// <copyright file="Question.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Xml.Serialization;

namespace FHTW.CodeRunner.ExportService.Entities
{
    [XmlRoot(ElementName = "question")]
    public class Question
    {
        [XmlElement(ElementName = "category")]
        public Category Category { get; set; }

        [XmlElement(ElementName = "info")]
        public Info Info { get; set; }

        [XmlElement(ElementName = "idnumber")]
        public string Idnumber { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "name")]
        public Name Name { get; set; }

        [XmlElement(ElementName = "questiontext")]
        public Questiontext Questiontext { get; set; }

        [XmlElement(ElementName = "generalfeedback")]
        public Generalfeedback Generalfeedback { get; set; }

        [XmlElement(ElementName = "defaultgrade")]
        public string Defaultgrade { get; set; }

        [XmlElement(ElementName = "penalty")]
        public string Penalty { get; set; }

        [XmlElement(ElementName = "hidden")]
        public string Hidden { get; set; }

        [XmlElement(ElementName = "coderunnertype")]
        public string Coderunnertype { get; set; }

        [XmlElement(ElementName = "prototypetype")]
        public string Prototypetype { get; set; }

        [XmlElement(ElementName = "allornothing")]
        public string Allornothing { get; set; }

        [XmlElement(ElementName = "penaltyregime")]
        public string Penaltyregime { get; set; }

        [XmlElement(ElementName = "precheck")]
        public string Precheck { get; set; }

        [XmlElement(ElementName = "showsource")]
        public string Showsource { get; set; }

        [XmlElement(ElementName = "answerboxlines")]
        public string Answerboxlines { get; set; }

        [XmlElement(ElementName = "answerboxcolumns")]
        public string Answerboxcolumns { get; set; }

        [XmlElement(ElementName = "answerpreload")]
        public string Answerpreload { get; set; }

        [XmlElement(ElementName = "globalextra")]
        public string Globalextra { get; set; }

        [XmlElement(ElementName = "useace")]
        public string Useace { get; set; }

        [XmlElement(ElementName = "resultcolumns")]
        public string Resultcolumns { get; set; }

        [XmlElement(ElementName = "template")]
        public string Template { get; set; }

        [XmlElement(ElementName = "iscombinatortemplate")]
        public string Iscombinatortemplate { get; set; }

        [XmlElement(ElementName = "allowmultiplestdins")]
        public string Allowmultiplestdins { get; set; }

        [XmlElement(ElementName = "answer")]
        public string Answer { get; set; }

        [XmlElement(ElementName = "validateonsave")]
        public string Validateonsave { get; set; }

        [XmlElement(ElementName = "testsplitterre")]
        public string Testsplitterre { get; set; }

        [XmlElement(ElementName = "language")]
        public string Language { get; set; }

        [XmlElement(ElementName = "acelang")]
        public string Acelang { get; set; }

        [XmlElement(ElementName = "sandbox")]
        public string Sandbox { get; set; }

        [XmlElement(ElementName = "grader")]
        public string Grader { get; set; }

        [XmlElement(ElementName = "cputimelimitsecs")]
        public string Cputimelimitsecs { get; set; }

        [XmlElement(ElementName = "memlimitmb")]
        public string Memlimitmb { get; set; }

        [XmlElement(ElementName = "sandboxparams")]
        public string Sandboxparams { get; set; }

        [XmlElement(ElementName = "templateparams")]
        public string Templateparams { get; set; }

        [XmlElement(ElementName = "hoisttemplateparams")]
        public string Hoisttemplateparams { get; set; }

        [XmlElement(ElementName = "twigall")]
        public string Twigall { get; set; }

        [XmlElement(ElementName = "uiplugin")]
        public string Uiplugin { get; set; }

        [XmlElement(ElementName = "attachments")]
        public string Attachments { get; set; }

        [XmlElement(ElementName = "attachmentsrequired")]
        public string Attachmentsrequired { get; set; }

        [XmlElement(ElementName = "maxfilesize")]
        public string Maxfilesize { get; set; }

        [XmlElement(ElementName = "filenamesregex")]
        public string Filenamesregex { get; set; }

        [XmlElement(ElementName = "filenamesexplain")]
        public string Filenamesexplain { get; set; }

        [XmlElement(ElementName = "displayfeedback")]
        public string Displayfeedback { get; set; }

        [XmlElement(ElementName = "testcases")]
        public Testcases Testcases { get; set; }

        [XmlElement(ElementName = "tags")]
        public Tags Tags { get; set; }
    }
}
