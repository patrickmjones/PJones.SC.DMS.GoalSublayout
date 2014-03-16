using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Analytics.Data.DataAccess.DataSets;
using Sitecore.Analytics.Data.Items;
using Sitecore.Data.Items;

namespace PJones.SC.DMS.GoalSublayout.WebControls
{
	public class AchieveGoal : Sitecore.Web.UI.WebControl
	{
		protected override void DoRender(System.Web.UI.HtmlTextWriter output)
		{
			if (Sitecore.Analytics.Tracker.IsActive && Sitecore.Analytics.Tracker.CurrentPage != null)
			{
				var goalItem = this.GetItem();
				if (goalItem != null)
				{
					PageEventItem goal = new PageEventItem(goalItem);
					VisitorDataSet.PageEventsRow pageEventsRow = Sitecore.Analytics.Tracker.CurrentPage.Register(goal);
					pageEventsRow.Data = goalItem.TemplateName + " triggered from AchieveGoal";
					Sitecore.Analytics.Tracker.Submit();
				}
			}
		}
	}
}