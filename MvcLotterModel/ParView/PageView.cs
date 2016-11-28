namespace MvcLotterModel.ParView
{
    public class PageView<T> : PageBase
    {
        public T[] list { get; set; }
        public int Count { get; set; }

        int next { get { return PageIndex + 1; } }
        int prev { get { return PageIndex - 1; } }

        int pageCount { get { return (Count % PageSize) != 0 ? (Count / PageSize + 1) : (Count / PageSize); } }

        public string PageSizeStatus
        {
            get
            {
                return @"<div  style='display:none;'>                      
                                <input type='text' id='HidePageIndex' name='pageIndex' value=" + 1 + @" />
                                <input type='text' id='HidePageSize' name='pageSize' value=" + PageSize + @" />
                            </div>";
            }
        }
        public string PagerHtml
        {
            get
            {
                string html = @"<div class='row'>
                        <div class='col-sm-6'>
                            <div id='sample-table-2_length' class='dataTables_length'>
                                <label>
                                    显示
                                    <select id='pageSize' size='1' name='sample-table-2_length' aria-controls='sample-table-2' onchange='page(1)'>
                                        <option value='5'>5</option>
                                        <option value='10'>10</option>
                                        <option value='15'>15</option>
                                        <option value='50'>50</option>
                                    </select>
                                    条数
                                </label>
                                <div class='pull-right'>总共 " + Count + @" 条</div>
                            </div>
                        </div>
                        <div class='dataTables_paginate paging_bootstrap'>
                            <ul class='pagination'>";
                if (prev < 1)
                {
                    html += @" <li class='prev disabled'><a href='#'><i class='icon-double-angle-left'></i></a></li>
                                <li class='prev disabled'><a href='#'><i class='icon-angle-left'></i></a></li>";
                }
                else
                {
                    html += @"  <li class='prev'><a href='javascript:page(1)'><i class='icon-double-angle-left'></i></a></li>
                                    <li class='prev'><a href='javascript:page(" + prev + @")'><i class='icon-angle-left'></i></a></li>";
                }
                html += @"<li class='active'><a href='#'>" + PageIndex + "/" + pageCount + "</a></li>";

                if (next > pageCount)
                {
                    html += @"<li class='next disabled'><a href='#'><i class='icon-angle-right'></i></a></li>
                        <li class='next disabled'><a href='#'><i class='icon-double-angle-right'></i></a></li>";
                }
                else
                {
                    html += @" <li class='next'><a href='javascript:page(" + next + @")'><i class='icon-angle-right'></i></a></li>
                                    <li class='next'><a href='javascript:page(" + pageCount + ")'><i class='icon-double-angle-right'></i></a></li>";
                }
                html += @"</ul></div></div>";
                return html;
            }
        }
    }
}

