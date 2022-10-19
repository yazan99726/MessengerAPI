using Messenger.core.Data;
using Messenger.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.Repoisitory
{
    public interface ITestimonialRepository
    {
        public List<testimonial> GetAllTests();
        public bool InsertTest(testimonial test);
        public bool DeleteTest(int testId);
        public bool UpdateTest(testimonial test);
        public testimonial GetTestById(int testId);
        public bool AcceptTest(testimonial test);
        public bool RejectTest(testimonial test);
        public List<testimonial> GetUserById(int  userId);
        public List<GetTestimonialByUserName> Getpublishdate(GetTestimonialByUserName testimonial);
        public List<GetTestimonialShow> GetTestimonialShow();
        public List<GetTestimonialByUserName> GetTestimonialByUserName();
    }
}
