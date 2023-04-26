using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SajjadArash.ToDoApp.Infrastructure.Mapping
{
    /// <summary>
    /// جهت رجیستر کردن خودکار تایپ ها در اتومپر
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IMapFrom<TModel>
    {
        void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(TModel));
    }
}
