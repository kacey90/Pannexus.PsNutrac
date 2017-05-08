using Abp.Web.Mvc.Views;

namespace Pannexus.PsNutrac.Web.Views
{
    public abstract class SampleLTEWebViewPageBase : SampleLTEWebViewPageBase<dynamic>
    {

    }

    public abstract class SampleLTEWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected SampleLTEWebViewPageBase()
        {
            LocalizationSourceName = SampleLTEConsts.LocalizationSourceName;
        }
    }
}