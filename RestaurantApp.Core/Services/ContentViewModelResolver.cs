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


        public static ContentView ResolveViewModel<T>() where T : BaseViewModel
        {
            return ResolveViewModel<T>(null);
        }


        public static ContentView ResolveViewModel<T>(object initData) where T : BaseViewModel
        {
            var pageModel = FreshIOC.Container.Resolve<T>();


            return ResolveViewModel(initData, pageModel);
        }


        public static ContentView ResolveViewModel<T>(object data, T viewModel) where T : BaseViewModel
        {
            var type = viewModel.GetType();

            return ResolveViewModel(type, data, viewModel);
        }


        public static ContentView ResolveViewModel(Type type, object data)
        {
            var viewModel = FreshIOC.Container.Resolve(type) as BaseViewModel;

            return ResolveViewModel(type, data, viewModel);
        }


        public static ContentView ResolveViewModel(Type type, object data, BaseViewModel viewModel)
        {
            var name = ViewModelMapper.GetViewTypeName(type);

            var viewType = Type.GetType(name);

            if (viewType == null)

                throw new Exception(name + " not found");

            var view =(ContentView)FreshIOC.Container.Resolve(viewType);


         BindingPageModel(data, view, viewModel);


            return view;
        }


        public static ContentView BindingPageModel(object data, ContentView targetPage, BaseViewModel viewModel)
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