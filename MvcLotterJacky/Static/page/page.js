function page(currPage) {
    var pageSize = $('#pageSize').val();
    if (pageSize == "") {
        pageSize = 10;
    }
    var json_url = "";
    if (location.href.indexOf("pageIndex=") > 0) {
        if (location.href.indexOf("?pageIndex=") > 0) {
            json_url = location.href.substr(0, location.href.indexOf("?pageIndex=")) + "?pageIndex=" + currPage + "&pageSize=" + pageSize;
        }
        else {
            json_url = location.href.substr(0, location.href.indexOf("pageIndex=")) + "pageIndex=" + currPage + "&pageSize=" + pageSize;
        }
    }
    else {
        json_url = location.href.substr(0, location.href.indexOf("?")) + "?pageIndex=" + currPage + "&pageSize=" + pageSize;
    }
    location.href = json_url;

}