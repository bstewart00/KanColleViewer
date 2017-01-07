using Grabacr07.KanColleWrapper;
using Grabacr07.KanColleWrapper.Models;

namespace Grabacr07.KanColleViewer.ViewModels.Contents
{
    public class OrganizationModel
    {
        public MemberTable<Ship> Ships { get; set; }
        public MemberTable<SlotItem> Items { get; set; }
    }
}