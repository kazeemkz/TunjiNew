using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using eLibrary.Model;
using SchoolManagement.Model;

namespace SchoolManagement.Models
{
    public class QuestionViewModel
    {
        public List<Question> TheQuestions { get; set; }
        public List<Choice> TheChoices { get; set; }

        public QuestionViewModel()
        {
            TheQuestions = new List<Question>();
            TheChoices = new List<Choice>();
        }

    }
}