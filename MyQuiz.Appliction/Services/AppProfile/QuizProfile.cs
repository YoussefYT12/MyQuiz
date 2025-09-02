using AutoMapper;
using MyQuiz.Domain.Entities;
using MyQuiz.Dtos.QuestionChoiceDto;
using MyQuiz.Dtos.QuestionDto;
using MyQuiz.Dtos.QuizDto;
using MyQuiz.Dtos.QuizQuestionDto;
using MyQuiz.Dtos.QuizStudentDto;
//using MyQuiz.Dtos.RoleDto;
using MyQuiz.Dtos.UserDto;
using MyQuiz.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Appliction.Services.AppProfile
{
    public class QuizProfile : Profile
    {
        public QuizProfile()
        {
           
            CreateMap<Priv_User, LoginDto>().ReverseMap();

            



            CreateMap<Lk_Question, QuestionAddDto>().ReverseMap();
            CreateMap<Lk_Question, QuestionGetDto>().ReverseMap();
            CreateMap<Lk_Question, QuestionUpdateDto>().ReverseMap();

            CreateMap<Lk_Choice, ChoiceAddDto>().ReverseMap();
            CreateMap<Lk_Choice, ChoiceGetDto>().ReverseMap();

            CreateMap<Lk_Quiz, QuizAddDto>().ReverseMap();
            CreateMap<Lk_Quiz, QuizGetDto>().ReverseMap();
            CreateMap<Lk_Quiz, QuizUpdateDto>().ReverseMap();
            

            
            CreateMap<Lk_QuizQuestion, QuizQuestionAddDto>().ReverseMap();
            CreateMap<Lk_QuizQuestion, QuizQuestionGetDto>().ReverseMap();

            CreateMap<Tr_QuizStudent, QuizStudentGetDto>().ReverseMap();

          
            

        }
    }
}
