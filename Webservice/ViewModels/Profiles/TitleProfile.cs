using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Rawdata_Porfolio_2;
using Rawdata_Porfolio_2.Pages.Entity_Framework.Domain;

namespace Webservice.ViewModels.Profiles
{
    public class TitleProfile : Profile
    {
        public TitleProfile()
        {
            CreateMap<Title, TitleViewModel>();
            CreateMap<TitleViewModel, Title>();
            CreateMap<CreateTitleViewModel, Title>();
        }
    }
}