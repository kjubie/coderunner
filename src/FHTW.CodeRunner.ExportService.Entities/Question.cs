// <copyright file="Question.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Xml.Serialization;

namespace FHTW.CodeRunner.ExportService.Entities
{
    /// <summary>
    /// Entity that describes the question.
    /// </summary>
    [XmlRoot(ElementName = "question")]
    public class Question
    {
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        [XmlElement(ElementName = "category")]
        public Category Category { get; set; }

        /// <summary>
        /// Gets or sets the info.
        /// </summary>
        [XmlElement(ElementName = "info")]
        public Info Info { get; set; }

        /// <summary>
        /// Gets or sets the idnumber.
        /// </summary>
        [XmlElement(ElementName = "idnumber")]
        public string Idnumber { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [XmlElement(ElementName = "name")]
        public Name Name { get; set; }

        /// <summary>
        /// Gets or sets the questiontext.
        /// </summary>
        [XmlElement(ElementName = "questiontext")]
        public Questiontext Questiontext { get; set; }

        /// <summary>
        /// Gets or sets the general feedback.
        /// </summary>
        [XmlElement(ElementName = "generalfeedback")]
        public Generalfeedback Generalfeedback { get; set; }

        /// <summary>
        /// Gets or sets the defaultgrade.
        /// </summary>
        [XmlElement(ElementName = "defaultgrade")]
        public string Defaultgrade { get; set; }

        /// <summary>
        /// Gets or sets the penalty.
        /// </summary>
        [XmlElement(ElementName = "penalty")]
        public string Penalty { get; set; }

        /// <summary>
        /// Gets or sets the hidden flag.
        /// </summary>
        [XmlElement(ElementName = "hidden")]
        public string Hidden { get; set; }

        /// <summary>
        /// Gets or sets the coderunner type.
        /// </summary>
        [XmlElement(ElementName = "coderunnertype")]
        public string Coderunnertype { get; set; }

        /// <summary>
        /// Gets or sets the prototype type.
        /// </summary>
        [XmlElement(ElementName = "prototypetype")]
        public string Prototypetype { get; set; }

        /// <summary>
        /// Gets or sets the allornothing flag.
        /// </summary>
        [XmlElement(ElementName = "allornothing")]
        public string Allornothing { get; set; }

        /// <summary>
        /// Gets or sets the penalty regime.
        /// </summary>
        [XmlElement(ElementName = "penaltyregime")]
        public string Penaltyregime { get; set; }

        /// <summary>
        /// Gets or sets the precheck flag.
        /// </summary>
        [XmlElement(ElementName = "precheck")]
        public string Precheck { get; set; }

        /// <summary>
        /// Gets or sets the showsource flag.
        /// </summary>
        [XmlElement(ElementName = "showsource")]
        public string Showsource { get; set; }

        /// <summary>
        /// Gets or sets the answerbox lines.
        /// </summary>
        [XmlElement(ElementName = "answerboxlines")]
        public string Answerboxlines { get; set; }

        /// <summary>
        /// Gets or sets the answerbox columns.
        /// </summary>
        [XmlElement(ElementName = "answerboxcolumns")]
        public string Answerboxcolumns { get; set; }

        /// <summary>
        /// Gets or sets the answerpreload flag.
        /// </summary>
        [XmlElement(ElementName = "answerpreload")]
        public string Answerpreload { get; set; }

        /// <summary>
        /// Gets or sets the globalextra.
        /// </summary>
        [XmlElement(ElementName = "globalextra")]
        public string Globalextra { get; set; }

        /// <summary>
        /// Gets or sets the useace.
        /// </summary>
        [XmlElement(ElementName = "useace")]
        public string Useace { get; set; }

        /// <summary>
        /// Gets or sets the result columns.
        /// </summary>
        [XmlElement(ElementName = "resultcolumns")]
        public string Resultcolumns { get; set; }

        /// <summary>
        /// Gets or sets the template.
        /// </summary>
        [XmlElement(ElementName = "template")]
        public string Template { get; set; }

        /// <summary>
        /// Gets or sets the iscombinatortemplate flag.
        /// </summary>
        [XmlElement(ElementName = "iscombinatortemplate")]
        public string Iscombinatortemplate { get; set; }

        /// <summary>
        /// Gets or sets the allowmultiplestdins flag.
        /// </summary>
        [XmlElement(ElementName = "allowmultiplestdins")]
        public string Allowmultiplestdins { get; set; }

        /// <summary>
        /// Gets or sets the answer.
        /// </summary>
        [XmlElement(ElementName = "answer")]
        public string Answer { get; set; }

        /// <summary>
        /// Gets or sets the validateonsave flag.
        /// </summary>
        [XmlElement(ElementName = "validateonsave")]
        public string Validateonsave { get; set; }

        /// <summary>
        /// Gets or sets the testsplitterre.
        /// </summary>
        [XmlElement(ElementName = "testsplitterre")]
        public string Testsplitterre { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        [XmlElement(ElementName = "language")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the acelang.
        /// </summary>
        [XmlElement(ElementName = "acelang")]
        public string Acelang { get; set; }

        /// <summary>
        /// Gets or sets the sandbox.
        /// </summary>
        [XmlElement(ElementName = "sandbox")]
        public string Sandbox { get; set; }

        /// <summary>
        /// Gets or sets the grader.
        /// </summary>
        [XmlElement(ElementName = "grader")]
        public string Grader { get; set; }

        /// <summary>
        /// Gets or sets the cputimelimitsecs.
        /// </summary>
        [XmlElement(ElementName = "cputimelimitsecs")]
        public string Cputimelimitsecs { get; set; }

        /// <summary>
        /// Gets or sets the memlimitmb.
        /// </summary>
        [XmlElement(ElementName = "memlimitmb")]
        public string Memlimitmb { get; set; }

        /// <summary>
        /// Gets or sets the sandboxparams.
        /// </summary>
        [XmlElement(ElementName = "sandboxparams")]
        public string Sandboxparams { get; set; }

        /// <summary>
        /// Gets or sets the templateparams.
        /// </summary>
        [XmlElement(ElementName = "templateparams")]
        public string Templateparams { get; set; }

        /// <summary>
        /// Gets or sets the hoisttemplateparams.
        /// </summary>
        [XmlElement(ElementName = "hoisttemplateparams")]
        public string Hoisttemplateparams { get; set; }

        /// <summary>
        /// Gets or sets the twigall flag.
        /// </summary>
        [XmlElement(ElementName = "twigall")]
        public string Twigall { get; set; }

        /// <summary>
        /// Gets or sets the uiplugin.
        /// </summary>
        [XmlElement(ElementName = "uiplugin")]
        public string Uiplugin { get; set; }

        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        [XmlElement(ElementName = "attachments")]
        public string Attachments { get; set; }

        /// <summary>
        /// Gets or sets the attachmentsrequired flag.
        /// </summary>
        [XmlElement(ElementName = "attachmentsrequired")]
        public string Attachmentsrequired { get; set; }

        /// <summary>
        /// Gets or sets the maxfilesize.
        /// </summary>
        [XmlElement(ElementName = "maxfilesize")]
        public string Maxfilesize { get; set; }

        /// <summary>
        /// Gets or sets the filenamesregex.
        /// </summary>
        [XmlElement(ElementName = "filenamesregex")]
        public string Filenamesregex { get; set; }

        /// <summary>
        /// Gets or sets the filenamesexplain.
        /// </summary>
        [XmlElement(ElementName = "filenamesexplain")]
        public string Filenamesexplain { get; set; }

        /// <summary>
        /// Gets or sets the displayfeedback.
        /// </summary>
        [XmlElement(ElementName = "displayfeedback")]
        public string Displayfeedback { get; set; }

        /// <summary>
        /// Gets or sets the testcases.
        /// </summary>
        [XmlElement(ElementName = "testcases")]
        public Testcases Testcases { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [XmlElement(ElementName = "tags")]
        public Tags Tags { get; set; }
    }
}
