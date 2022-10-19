using Messenger.core.Data;
using Messenger.core.DTO;
using Messenger.core.Repoisitory;
using Messenger.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.infra.Service
{
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository testimonialRepository;

        public TestimonialService(ITestimonialRepository testimonialRepository)
        {
            this.testimonialRepository = testimonialRepository;
        }
        public bool DeleteTest(int testId)
        {
            return testimonialRepository.DeleteTest(testId);
        }

        public List<testimonial> GetAllTests()
        {
            return testimonialRepository.GetAllTests();
        }

        public testimonial GetTestById(int testId)
        {
            return testimonialRepository.GetTestById(testId);
        }

        public bool InsertTest(testimonial test)
        {
            return testimonialRepository.InsertTest(test);
        }
        public bool UpdateTest(testimonial test)
        {
            return testimonialRepository.UpdateTest(test);
        }
        public bool AcceptTest(testimonial test)
        {
            return testimonialRepository.AcceptTest(test);
        }
        public bool RejectTest(testimonial test)
        {
            return testimonialRepository.RejectTest(test);
        }
        public List<testimonial> GetUserById(int userId)
        {
            return testimonialRepository.GetUserById(userId);
        }
        public List<GetTestimonialByUserName> Getpublishdate(GetTestimonialByUserName test)
        {
            return testimonialRepository.Getpublishdate(test);
        }
        public List<GetTestimonialShow> GetTestimonialShow()
        {
            List<GetTestimonialShow> gt = testimonialRepository.GetTestimonialShow();
            List<GetTestimonialShow> selected = new List<GetTestimonialShow>();

            HashSet<int> rand = new HashSet<int>();
            Random rnd = new Random();

            while (rand.Count < 7)
            {
                rand.Add(rnd.Next(gt.Count));
            }

            foreach (var item in rand)
            {
                selected.Add(gt[item]);
            }

                return selected;
        }
        public List<GetTestimonialByUserName> GetTestimonialByUserName()
        {
            return testimonialRepository.GetTestimonialByUserName();
        }
    }
}
