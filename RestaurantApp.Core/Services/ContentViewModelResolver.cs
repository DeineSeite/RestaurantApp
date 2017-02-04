using System;
using FreshMvvm;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.ViewModels;
using Xamarin.Forms;

namespace RestaurantApp.Core.Services
{
    public static class ContentViewModelResolver
    {
        public static IContentViewModelMapper ViewModelMapper { get; set; } = new ContentViewModelMapper();


        public static BaseContentView ResolveViewModel<T>() where T : BaseViewModel
        {
            return ResolveViewModel<T>(null);
        }


        public static BaseContentView ResolveViewModel<T>(object initData) where T : BaseViewModel
        {
            var pageModel = FreshIOC.Container.Resolve<T>();


            return ResolveViewModel(initData, pageModel);
        }


        public static BaseContentView ResolveViewModel<T>(object data, T viewModel) where T : BaseViewModel
        {
            var type = viewModel.GetType();

            return ResolveViewModel(type, data, viewModel);
        }


        public static BaseContentView ResolveViewModel(Type type, object data)
        {
            var viewModel = FreshIOC.Container.Resolve(type) as BaseViewModel;

            return ResolveViewModel(type, data, viewModel);
        }


        public static BaseContentView ResolveViewModel(Type type, object data, BaseViewModel viewModel)
        {
            var name = ViewModelMapper.GetViewTypeName(type);

            var viewType = Type.GetType(name);

            if (viewType == null)

                throw new Exception(name + " not found");

            var view =(BaseContentView)FreshIOC.Container.Resolve(viewType);


         BindingPageModel(data, view, viewModel);


            return view;
        }


        public static BaseContentView BindingPageModel(object data, BaseContentView targetPage, BaseViewModel viewModel)
        {
            // viewModel.WireEvents(targetPage);

            viewModel.CurreContentView = targetPage;

            //  viewModel.CoreMethods = new PageModelCoreMethods(targetPage, pageModel);

            viewModel.Init(data);

            targetPage.BindingContext = viewModel;

            return targetPage;
        }
    }
}