using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyLogger
{

    class Questions
    {
        //questionType: 
        // 0--Easy
        // 1--Intermediate
        // 2--Hard
        private int questionType;

        private string question;

        //modelIn:
        //ROWLTab Plugin or Standard Protege
        //1--Bare protege
        private string modelIn;
        private string [] owlClasses;
        private string [] owlObjectProperties;

        public Questions(int type, string question, string useTooltoModel)
        {
            this.QuestionType = type;
            this.Question = question;
            this.ModelIn = useTooltoModel;
        }


        public string ModelIn
        {
            get
            {
                return modelIn;
            }

            set
            {
                modelIn = value;
            }
        }

        public int QuestionType
        {
            get
            {
                return questionType;
            }

            set
            {
                questionType = value;
            }
        }

        public string Question
        {
            get
            {
                return question;
            }

            set
            {
                question = value;
            }
        }
    }
}
