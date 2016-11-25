
    function initMap(cityName) {

        var map = new BMap.Map("bdMap");
        map.clearOverlays();    //清除地图上所有覆盖物
        map.centerAndZoom(cityName, 12);                   // 初始化地图,设置城市和地图级别。
        map.enableScrollWheelZoom();
        map.enableContinuousZoom();
        var ac = new BMap.Autocomplete(    //建立一个自动完成的对象
            {
                "input": "Address"
            ,"location" : map
            });
        ac.addEventListener("onhighlight", function(e) {  //鼠标放在下拉列表上的事件
            var str = "";
            var _value = e.fromitem.value;
            var value = "";
            if (e.fromitem.index > -1) {
                value = _value.province +  _value.city +  _value.district +  _value.street +  _value.business;
            }    
            str = "FromItem<br />index = " + e.fromitem.index + "<br />value = " + value;
		
            value = "";
            if (e.toitem.index > -1) {
                _value = e.toitem.value;
                value = _value.province +  _value.city +  _value.district +  _value.street +  _value.business;
            }    
            str += "<br />ToItem<br />index = " + e.toitem.index + "<br />value = " + value;
        });

        var myValue;
        ac.addEventListener("onconfirm", function(e) {    //鼠标点击下拉列表后的事件
            var _value = e.item.value;
            myValue = _value.province + _value.city + _value.district + _value.street + _value.business;
            //标注位置
            map.clearOverlays();    //清除地图上所有覆盖物
            function myFun() {
                var pp = local.getResults().getPoi(0).point;    //获取第一个智能搜索的结果
                map.centerAndZoom(pp, 18);
                map.addOverlay(new BMap.Marker(pp));    //添加标注
            }
            var local = new BMap.LocalSearch(map, { //智能搜索
                onSearchComplete: myFun
            });
            local.search(myValue);
        });
    }

    function initDsMap(cityName) {

        var map = new BMap.Map("bdMap");
        map.clearOverlays();    //清除地图上所有覆盖物
        map.centerAndZoom(cityName, 12);                   // 初始化地图,设置城市和地图级别。
        map.enableScrollWheelZoom();
        map.enableContinuousZoom();
    }
    function initDsMapShow(cityName, address) {
        // 百度地图API功能
        var map = new BMap.Map("bdMap"); 
        // 创建地址解析器实例
        var myGeo = new BMap.Geocoder();
        // 将地址解析结果显示在地图上,并调整地图视野
        myGeo.getPoint(address, function (point) {
            if (point) {
                map.centerAndZoom(point, 12);
                map.addOverlay(new BMap.Marker(point));
                map.enableScrollWheelZoom();   
                map.enableContinuousZoom();    
            } else {
                alert("您选择地址没有解析到结果!");
            }
        }, cityName);
    }