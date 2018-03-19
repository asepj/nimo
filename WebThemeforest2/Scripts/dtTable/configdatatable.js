
$(function () {
    var hash = window.location.hash;
    hash && $('ul.nav a[href="' + hash + '"]').tab('show');

    $('.nav-tabs a').click(function (e) {
        $(this).tab('show');
        var scrollmem = $('body').scrollTop() || $('html').scrollTop();
        window.location.hash = this.hash;
        $('html,body').scrollTop(scrollmem);
    });
});

var table;

$(document).ready(function () {
    table = $('#tblarea').DataTable({
        "iDisplayLength": 10,
        "bStateSave": true,
        //"aLengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
        "ajax": {
            "url": url_api_set_dashboard,
            "dataSrc": ''
        },
        "columns": [
        {
            "data": null, "className": "ID", render: function (item, type, row) {
                return "<span>" + item.ID + "</span>" +
                "<input type='text' value='" + item.ID + "' style='display:none' />";

            }
        },

        {
            "data": null, "className": "Area", render: function (item, type, row) {
                return "<span>" + item.AREA + "</span>" +
                "<input type='text' value='" + item.AREA + "' style='display:none' />";
            }
        },
       {
           "data": null, "className": "Name", render: function (item, type, row) {
               return "<span>" + item.NAME + "</span>" +
               "<input type='text' value='" + item.NAME + "' style='display:none' />";
           }
       },
       {
           "data": null, "className": "CapacityMax", render: function (item, type, row) {
               return "<span>" + item.CAPACITY_MAX + "</span>" +
             "<input type='text' value='" + item.CAPACITY_MAX + "' style='display:none' />";
           }
       },
          {
              "data": null,
              "className": "center",
              "defaultContent": "<a class='Edit' href='javascript:;'>Edit</a>"
                + " <a class='Update' href='javascript:;' style='display:none'>Update</a>"
                + " <a class='Cancel' href='javascript:;' style='display:none'>Cancel</a>"
                + " <a class='Delete' href='javascript:;'>Delete</a>"

          }
        ],
        "createdRow": function (row, data, index) {
            $('td', row).eq(0).addClass("hidetd");
        },

    });

});


$("body").on("click", "#btnAdd", function () {
    var txtArea = $("#txtArea");
    var txtName = $("#txtAreaName");
    var txtCapacityMax = $("#txtCapacityMax");
    $.ajax({
        type: "POST",
        url: url_api_set_dashboard,
        data: '{AREA: "' + txtArea.val() + '", NAME: "' + txtName.val() + '", CAPACITY_MAX: "' + txtCapacityMax.val() + '"  }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            $(function () {
                $('#myModal').modal('toggle');
            });
            alert("Data Saved");
            $('#tblarea').DataTable().ajax.reload(null, false);
        }
    });
});
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Edit event handler.
$("body").on("click", "#tblarea .Edit", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            $(this).find("input").show();
            $(this).find("span").hide();
        }
    });
    row.find(".Update").show();
    row.find(".Cancel").show();
    row.find(".Delete").hide();
    $(this).hide();


});

//Update event handler.
$("body").on("click", "#tblarea .Update", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            var span = $(this).find("span");
            var input = $(this).find("input");
            span.html(input.val());
            span.show();
            input.hide();
        }
    });
    row.find(".Edit").show();
    row.find(".Delete").show();
    row.find(".Cancel").hide();
    $(this).hide();


    var pl_config_dashboard = {};
    pl_config_dashboard.ID = row.find(".ID").find("span").html();
    pl_config_dashboard.AREA = row.find(".Area").find("span").html();
    pl_config_dashboard.NAME = row.find(".Name").find("span").html();
    pl_config_dashboard.CAPACITY_MAX = row.find(".CapacityMax").find("span").html();


    $.ajax({
        type: "Put",
        url: url_api_set_dashboard,
        data: JSON.stringify(pl_config_dashboard),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });
});
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Cancel event handler.
$("body").on("click", "#tblarea .Cancel", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            var span = $(this).find("span");
            var input = $(this).find("input");
            input.val(span.html());
            span.show();
            input.hide();
        }
    });
    row.find(".Edit").show();
    row.find(".Delete").show();
    row.find(".Update").hide();
    $(this).hide();
});

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//Delete event handler.
$("body").on("click", "#tblarea .Delete", function () {
    if (confirm("Do you want to delete this row?")) {
        var row = $(this).closest("tr");
        var pl_config_dashboard = {};
        pl_config_dashboard.ID = row.find(".ID").find("span").html();
        $.ajax({
            type: "Delete",
            url: url_api_set_dashboard,
            data: JSON.stringify(pl_config_dashboard),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                row.remove();
                $('#tblarea').DataTable().ajax.reload(null, false);
            }
        });
    }
});


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

var tableoverview;

tableoverview = $('#tblcolour').DataTable({
    "iDisplayLength": 5,
    "bStateSave": true,
    "aLengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
    "rowId": 'tes',
    "ajax": {
        "url": url_api_set_overview,
        "dataSrc": ''
    },
    "aaSorting":[[1,'asc']],
    "columns": [
    {
        "data": null, "className": "ID", render: function (item, type, row) {
            return "<span>" + item.ID + "</span>" +
            "<input type='text' value='" + item.ID + "' style='display:none' />";

        }
    },

    {
        "data": null, "className": "Min", render: function (item, type, row) {
            return "<span>" + item.MIN + "</span>" +
            "<input type='text' value='" + item.MIN + "' style='display:none' />";
        }
    },
   {
       "data": null, "className": "Max", render: function (item, type, row) {
           return "<span>" + item.MAX + "</span>" +
           "<input type='text' value='" + item.MAX + "' style='display:none' />";
       }
   },
   {
       "data": null, "className": "Colour", render: function (item, type, row) {
           return "<span  style='background-color:" + item.COLOUR + "'>" + item.COLOUR + "</span>" +
         "<input type='color' value='" + item.COLOUR + "' style='display:none' />";
       }
   },


    // {
    //     "data": null, "className": "AreaName", render: function (item, type, row) {
    //         return "<span>" + item.AREA_NAME + "</span>" +
//             "<input type='text' value='" + item.AREA_NAME + "' style='display:none' />";
    //     }
    // },
    {
        "data": null, "className":"typeMap", render: function (item, type, row) {
            return "<span>" + item.MAP_TYPE+ "</span>" ;
            // "<input type='text' value='" + item.MAP_TYPE + "' style='display:none' />";
        }
    },


      {
          "data": null,
          "className": "center",
          "defaultContent": "<a class='Edit' href='javascript:;'>Edit</a>"
            + " <a class='Update' href='javascript:;' style='display:none'>Update</a>"
            + " <a class='Cancel' href='javascript:;' style='display:none'>Cancel</a>"
            + " <a class='Delete' href='javascript:;'>Delete</a>"
              
      }
    ],
    "createdRow": function (row, data, index) {
        $('td', row).eq(0).addClass("hidetd");
          
    },

});


$.ajax({
    url: url_api_dashboard2 ,
    datatype: "JSON",
    type: "Get",
    success: function (data) {
     
        $.each(data, function (i, item) {
            $('#op1').append($('<option>', {
                value: item.AREA,
                text: item.NAME
            }));
           
        });

        $("#op1select option").each(function () {
            if ($(this).text() == "Kerawang")
                $(this).attr("selected", "selected");
        });
       
    }
});


$.ajax({
    url: url_api_dashboard2,
    datatype: "JSON",
    type: "Get",
    success: function (data) {

        $.each(data, function (i, item) {
            $('#op2').append($('<option>', {
                value: item.AREA,
                text: item.NAME
            }));
           
        });
        
    }
});


// dropdownchange area

$("#op1").change(function () {

    $('#tblcolour').dataTable().fnDestroy();
  
    var area = $('#op1 option:selected').text();
    var datapost = {};
    datapost.AREA_NAME = area;

   
   
    tableoverview = $('#tblcolour').dataTable({
        "iDisplayLength": 5,
        "processing": true,
        "serverSide": false,
        "bJQueryUI": true,
                  
        "bStateSave": true,
        "aLengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
        "ajax": {
            "url": url_api_set_overview + "/AreaSelect",
            "type": "POST",
            "data": datapost,
            "dataSrc": ''
        },
        "columns": [
        {
            "data": null, "className": "ID", render: function (item, type, row) {
                return "<span>" + item.ID + "</span>" +
                "<input type='text' value='" + item.ID + "' style='display:none' />";

            }
        },

        {
            "data": null, "className": "Min", render: function (item, type, row) {
                return "<span>" + item.MIN + "</span>" +
                "<input type='text' value='" + item.MIN + "' style='display:none' />";
            }
        },
       {
           "data": null, "className": "Max", render: function (item, type, row) {
               return "<span>" + item.MAX + "</span>" +
               "<input type='text' value='" + item.MAX + "' style='display:none' />";
           }
       },
       {
           "data": null, "className": "Colour", render: function (item, type, row) {
               return "<span  style='background-color:" + item.COLOUR + "'>" + item.COLOUR + "</span>" +
             "<input type='color' value='" + item.COLOUR + "' style='display:none' />";
           }
       },


        {
            "data": null, "className": "AreaName", render: function (item, type, row) {
                return "<span>" + item.AREA_NAME + "</span>" +
              "<input type='text' value='" + item.AREA_NAME + "' style='display:none' />";
            }
        },

          {
              "data": null,
              "className": "center",
              "defaultContent": "<a class='Edit' href='javascript:;'>Edit</a>"
                + " <a class='Update' href='javascript:;' style='display:none'>Update</a>"
                + " <a class='Cancel' href='javascript:;' style='display:none'>Cancel</a>"
                + " <a class='Delete' href='javascript:;'>Delete</a>"
              
          }
        ],
        "createdRow": function (row, data, index) {
            $('td', row).eq(0).addClass("hidetd");
            $(row).attr('id', "tes");
        },

    });

           
    // If you want totally refresh the datatable use this 
    //tableoverview.ajax.reload();
    tableoverview.ajax.reload(null, false);
    // If you want to refresh but keep the paging you can you this
    //myTable.ajax.reload(null, false);
           
});

// dropdownchange type map

$("#opTypeMap").change(function () {

    $('#tblcolour').dataTable().fnDestroy();
  
    var type = $('#opTypeMap option:selected').text();
    var datapost = {};
    datapost.AREA_NAME = "Kerawang";
    datapost.MAP_TYPE = type ;

    debugger;
   
    tableoverview = $('#tblcolour').dataTable({
        "iDisplayLength": 5,
        "processing": true,
        "serverSide": false,
        "bJQueryUI": true,
                  
        "bStateSave": true,
        "aLengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
        "ajax": {
            "url": url_api_set_overview +"/maptypeSelect",
            "type": "POST",
            "data": datapost,
            "dataSrc": ''
        },
        "columns": [
{
    "data": null, "className": "ID", render: function (item, type, row) {
        return "<span>" + item.ID + "</span>" +
        "<input type='text' value='" + item.ID + "' style='display:none' />";

    }
},

{
    "data": null, "className": "Min", render: function (item, type, row) {
        return "<span>" + item.MIN + "</span>" +
        "<input type='text' value='" + item.MIN + "' style='display:none' />";
    }
},
{
    "data": null, "className": "Max", render: function (item, type, row) {
        return "<span>" + item.MAX + "</span>" +
        "<input type='text' value='" + item.MAX + "' style='display:none' />";
    }
},
{
    "data": null, "className": "Colour", render: function (item, type, row) {
        return "<span  style='background-color:" + item.COLOUR + "'>" + item.COLOUR + "</span>" +
      "<input type='color' value='" + item.COLOUR + "' style='display:none' />";
    }
},


// {
//     "data": null, "className": "AreaName", render: function (item, type, row) {
//         return "<span>" + item.AREA_NAME + "</span>" +
//             "<input type='text' value='" + item.AREA_NAME + "' style='display:none' />";
//     }
// },
{
    "data": null, "className":"typeMap", render: function (item, type, row) {
        return "<span>" + item.MAP_TYPE+ "</span>" ;
        // "<input type='text' value='" + item.MAP_TYPE + "' style='display:none' />";
    }
},


{
    "data": null,
    "className": "center",
    "defaultContent": "<a class='Edit' href='javascript:;'>Edit</a>"
      + " <a class='Update' href='javascript:;' style='display:none'>Update</a>"
      + " <a class='Cancel' href='javascript:;' style='display:none'>Cancel</a>"
      + " <a class='Delete' href='javascript:;'>Delete</a>"
              
}
        ],
        "createdRow": function (row, data, index) {
            $('td', row).eq(0).addClass("hidetd");
            $(row).attr('id', "tes");
        },

    });

           
    // If you want totally refresh the datatable use this 
    //tableoverview.ajax.reload();
    tableoverview.ajax.reload(null, false);
    // If you want to refresh but keep the paging you can you this
    //myTable.ajax.reload(null, false);
           
});
        
        

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//Add event handler.

$("body").on("click", "#btnAddColour", function () {
    var txtMin = $("#txtMinCapacity");
    var txtMax = $("#txtMaxCapacity");
    var txtColour = document.getElementById("myColor").value;
    // var txtArea = $('#op2 option:selected').text(); //temporary not use,maybe someday
    // var txtCode = $('#op2 option:selected').val(); //temporary not use,maybe someday
    var txtArea = "Kerawang";
    var txtCode = "014";
    var txtMapType = $("#opTypeMapAdd").val();
    debugger;
    $.ajax({
        type: "POST",
        url: url_api_set_overview,
        data: '{MIN: "' + txtMin.val() + '", MAX: "' + txtMax.val() + '", COLOUR: "' + txtColour + '", ID_UNIT_USAHA:"'+  txtCode + '", AREA_NAME: "' + txtArea + '",MAP_TYPE: "' + txtMapType +'" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            $(function () {
                $('#colourModal').modal('toggle');
            });
            alert("Data Saved");
            $('#tblcolour').DataTable().ajax.reload(null, false);
           
        }
    });
});



////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Edit event handler.
$("body").on("click", "#tblcolour .Edit", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            $(this).find("input").show();
            $(this).find("span").hide();
        }
    });
    row.find(".Update").show();
    row.find(".Cancel").show();
    row.find(".Delete").hide();
    $(this).hide();
});

//Update event handler.
$("body").on("click", "#tblcolour .Update", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            var span = $(this).find("span");
            var input = $(this).find("input");
            span.text(input.val());
            span.css("background-color",input.val());
            span.show();
            input.hide();
        }
    });
    row.find(".Edit").show();
    row.find(".Delete").show();
    row.find(".Cancel").hide();
    $(this).hide();


    var pl_config_overview = {};
    pl_config_overview.ID = row.find(".ID").find("span").html();
    pl_config_overview.MIN = row.find(".Min").find("span").html();
    pl_config_overview.MAX = row.find(".Max").find("span").html();
    pl_config_overview.COLOUR = row.find(".Colour").find("span").html();
    // pl_config_overview.AREA_NAME = row.find(".AreaName").find("span").html(); temporarynotuse
    pl_config_overview.AREA_NAME ="Kerawang";
    pl_config_overview.MAP_TYPE = row.find(".typeMap").find("span").html();

    $.ajax({
        type: "Put",
        url: url_api_set_overview,
        data: JSON.stringify(pl_config_overview),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });
});

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Cancel event handler.
$("body").on("click", "#tblcolour .Cancel", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            var span = $(this).find("span");
            var input = $(this).find("input");
            input.val(span.html());
            span.show();
            input.hide();
        }
    });
    row.find(".Edit").show();
    row.find(".Delete").show();
    row.find(".Update").hide();
    $(this).hide();
});

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


//Delete event handler.
$("body").on("click", "#tblcolour .Delete", function () {
    if (confirm("Do you want to delete this row?")) {
        var row = $(this).closest("tr");
        var pl_config_overview = {};
        pl_config_overview.ID = row.find(".ID").find("span").html();
        $.ajax({
            type: "Delete",
            url: url_api_set_overview,
            data: JSON.stringify(pl_config_overview),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                row.remove();
                $('#tblcolour').DataTable().ajax.reload(null, false);

                //tableoverview.fnReloadAjax();
                //tableoverview.fnReloadAjax();
            }
        });
    }
});

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

$(document).ready(function () {
var table_MRS;

    table_MRS = $('#tblMRS').DataTable({
        "iDisplayLength": 5,
        "bStateSave": true,
        "aLengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
        "ajax": {
            "url": url_api_set_diameter,
            "dataSrc": ''
        },
        "columns": [
        {
            "data": null, "className": "ID_MRS", render: function (item, type, row) {
                return "<span>" + item.ID_MRS + "</span>" +
                "<input type='text' value='" + item.ID_MRS + "' style='display:none' />";

            }
        },
	  {
	      "data": null, "className": "MT", render: function (item, type, row) {
	          return "<span>" + item.MRS_TYPE + "</span>" +
              "<input type='text' value='" + item.MRS_TYPE + "' style='display:none' />";
	      }
	  },

        {
            "data": null, "className": "MC", render: function (item, type, row) {
				
				
				var x = item.MATERIAL_COST;
				
				//if ( x == null)
				//{
				//	x = 0;
				//}
		        //x = x.toString();
		        //var lastThree = x.substring(x.length - 3);
		        //var otherNumbers = x.substring(0, x.length - 3);
		        //if (otherNumbers != '')
		        //    lastThree = ',' + lastThree;
		        //var res = "Rp " + otherNumbers.replace(/\B(?=(\d{2})+(?!\d))/g, ",") + lastThree;
				
				var Rupiah = accounting.formatMoney(x, "Rp ", 2, ".", ",");
				return "<span>" + Rupiah + "</span>" +
				

                "<input type='text' value='" + item.MATERIAL_COST + "' style='display:none' />";
            }
        },
		
		{
		    "data": null, "className": "CC", render: function (item, type, row) {
				
				var x = item.CONSTRUCTION_COST;
				
				//if ( x == null)
				//{
				//	x = 0;
				//}
		        //x = x.toString();
		        //var lastThree = x.substring(x.length - 3);
		        //var otherNumbers = x.substring(0, x.length - 3);
		        //if (otherNumbers != '')
		        //    lastThree = ',' + lastThree;
		        //var res = "Rp " + otherNumbers.replace(/\B(?=(\d{2})+(?!\d))/g, ",") + lastThree;


				var Rupiah = accounting.formatMoney(x, "Rp ", 2, ".", ",");
				return "<span>" + Rupiah + "</span>" +
				
		        
                "<input type='text' value='" + item.CONSTRUCTION_COST + "' style='display:none' />";
		    }
		},
		{
		    "data": null, "className": "MF", render: function (item, type, row) {
		        return "<span>" + item.MAX_FLOW + "</span>" +
                "<input type='text' value='" + item.MAX_FLOW + "' style='display:none' />";
		    }
		},
		


          {
              "data": null,
              "className": "center",
              "defaultContent": "<a class='Edit' href='javascript:;'>Edit</a>"
                + " <a class='Update' href='javascript:;' style='display:none'>Update</a>"
                + " <a class='Cancel' href='javascript:;' style='display:none'>Cancel</a>"
                //+ " <a class='Delete' href='javascript:;'>Delete</a>"
              //data: null, render: function (data, type, row) {
              //    // Combine the first and last names into a single table field
              //    return data.CustomerID + ' ' + data.Nama;
              //}
          }
        ],
        "createdRow": function (row, data, index) {
            $('td', row).eq(0).addClass("hidetd");

        }
        
        

    });
});


$("body").on("click", "#btnAddMRS", function () {
    var txtMRSType = $("#txtMRSType");
    var txtMaterialCost = $("#txtMaterialCost");
    var txtConstructionCost = $("#txtConstructionCost");
    var txtMaxFlow = $("#txtMaxFlow");
  


    $.ajax({
        type: "POST",
        url: url_api_set_diameter,
        data: '{MRS_TYPE: "' + txtMRSType.val() + '",MATERIAL_COST: "' + txtMaterialCost.val() + '",CONSTRUCTION_COST: "' + txtConstructionCost.val() + '",MAX_FLOW: "' + txtMaxFlow.val() + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            $(function () {
                $('#mrsModal').modal('toggle');
            });
            alert("Data Saved");
            //window.location.href = "/home/Settings";
            $('#tblMRS').DataTable().ajax.reload(null, false);
        }
    });
});
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Edit event handler.
$("body").on("click", "#tblMRS .Edit", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            $(this).find("input").show();
            $(this).find("span").hide();
        }
    });
    row.find(".Update").show();
    row.find(".Cancel").show();
    row.find(".Delete").hide();
    $(this).hide();
});

//Update event handler.
$("body").on("click", "#tblMRS .Update", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            var span = $(this).find("span");
            var input = $(this).find("input");
            span.html(input.val());
            span.show();
            input.hide();
        }
    });
    row.find(".Edit").show();
    row.find(".Delete").show();
    row.find(".Cancel").hide();
    $(this).hide();


    var pl_config_pipeline_mrs = {};
    pl_config_pipeline_mrs.ID_MRS = row.find(".ID").find("span").html();
    pl_config_pipeline_mrs.MRS_TYPE = row.find(".MT").find("span").html();
    pl_config_pipeline_mrs.MATERIAL_COST = row.find(".MC").find("span").html();
    pl_config_pipeline_mrs.CONSTRUCTION_COST = row.find(".CC").find("span").html();
    pl_config_pipeline_mrs.MAX_FLOW = row.find(".MF").find("span").html();
   


    $.ajax({
        type: "Put",
        url: url_api_set_diameter,
        data: JSON.stringify(pl_config_pipeline_mrs),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });
});
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Cancel event handler.
$("body").on("click", "#tblMRS .Cancel", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            var span = $(this).find("span");
            var input = $(this).find("input");
            input.val();
            span.show();
            input.hide();
        }
    });
    row.find(".Edit").show();
    row.find(".Delete").show();
    row.find(".Update").hide();
    $(this).hide();
});

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//Delete event handler.
$("body").on("click", "#tblMRS .Delete", function () {
    if (confirm("Do you want to delete this row?")) {
        var row = $(this).closest("tr");
        var pl_config_pipeline_mrs = {};
        pl_config_pipeline_mrs.ID_MRS = row.find(".ID_MRS").find("span").html();
        $.ajax({
            type: "Delete",
            url: url_api_set_diameter,
            data: JSON.stringify(pl_config_pipeline_mrs),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                row.remove();
                $('#tbldiameter').DataTable().ajax.reload(null, false);
            }
        });
    }
});


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


var table_temperature;

$(document).ready(function () {

    table_temperature = $('#tblTemperature').DataTable({
        "iDisplayLength": 5,
        "bStateSave": true,
        "aLengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
        "ajax": {
            "url": url_api_set_temperature,
            "dataSrc": ''
        },
        "columns": [
        {
            "data": null, "className": "ID", render: function (item, type, row) {
                return "<span>" + item.ID + "</span>" +
                "<input type='text' value='" + item.ID + "' style='display:none' />";

            }
        },

        {
            "data": null, "className": "CN", render: function (item, type, row) {
                return "<span>" + item.CONSTANT_NAME + "</span>" +
                "<input type='text' value='" + item.CONSTANT_NAME + "' style='display:none' />";
            }
        },
		{
		    "data": null, "className": "Value", render: function (item, type, row) {
		        return "<span>" + item.VALUE + "</span>" +
                "<input type='text' value='" + item.VALUE + "' style='display:none' />";
		    }
		},

          {
              "data": null,
              "className": "center",
              "defaultContent": "<a class='Edit' href='javascript:;'>Edit</a>"
                + " <a class='Update' href='javascript:;' style='display:none'>Update</a>"
                + " <a class='Cancel' href='javascript:;' style='display:none'>Cancel</a>"
                //+ " <a class='Delete' href='javascript:;'>Delete</a>"
              //data: null, render: function (data, type, row) {
              //    // Combine the first and last names into a single table field
              //    return data.CustomerID + ' ' + data.Nama;
              //}
          }
        ],
        "createdRow": function (row, data, index) {
            $('td', row).eq(0).addClass("hidetd");
        },

    });

});

$("body").on("click", "#btnAddTemperature", function () {
    var txtConstantName = $("#txtConstantName");
    var txtValue = $("#txtValue");

    $.ajax({
        type: "POST",
        url: url_api_set_temperature,
        data: '{CONSTANT_NAME: "' + txtConstantName.val() + '" , VALUE: "' + txtValue.val() + '"  }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            $(function () {
                $('#temperatureModal').modal('toggle');
            });
            //window.location.href = "/home/Settings";
            alert("Data Saved");
            $('#tblTemperature').DataTable().ajax.reload(null, false);
        }
    });
});

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////Edit event handler.
$("body").on("click", "#tblTemperature .Edit", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            $(this).find("input").show();
            $(this).find("span").hide();
        }
    });
    row.find(".Update").show();
    row.find(".Cancel").show();
    row.find(".Delete").hide();
    $(this).hide();



});

//Update event handler.
$("body").on("click", "#tblTemperature .Update", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            var span = $(this).find("span");
            var input = $(this).find("input");
            span.html(input.val());
            span.show();
            input.hide();
        }
    });
    row.find(".Edit").show();
    row.find(".Delete").show();
    row.find(".Cancel").hide();
    $(this).hide();


    var pl_config_constant = {};
    pl_config_constant.ID = row.find(".ID").find("span").html();
    pl_config_constant.CONSTANT_NAME = row.find(".CN").find("span").html();
    pl_config_constant.VALUE = row.find(".Value").find("span").html();



    $.ajax({
        type: "Put",
        url: url_api_set_temperature,
        data: JSON.stringify(pl_config_constant),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });
});
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Cancel event handler.
$("body").on("click", "#tblTemperature .Cancel", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            var span = $(this).find("span");
            var input = $(this).find("input");
            input.val(span.html());
            span.show();
            input.hide();
        }
    });
    row.find(".Edit").show();
    row.find(".Delete").show();
    row.find(".Update").hide();
    $(this).hide();
});

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


//Delete event handler.
$("body").on("click", "#tblTemperature .Delete", function () {
    if (confirm("Do you want to delete this row?")) {
        var row = $(this).closest("tr");
        var pl_config_constant = {};
        pl_config_constant.ID = row.find(".ID").find("span").html();
        $.ajax({
            type: "Delete",
            url: url_api_set_temperature,
            data: JSON.stringify(pl_config_constant),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                row.remove();
                $('#tblTemperature').DataTable().ajax.reload(null, false);
            }
        });
    }
});





var table_pipeCost;

$(document).ready(function () {

    table_pipeCost= $('#tblpipeCost').DataTable({
        "iDisplayLength": 5,
        "bStateSave": true,
        "aLengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
        "ajax": {
            "url": url_api_set_pipeCost,
            "dataSrc": ''
        },
        "columns": [
        {
            "data": null, "className": "ID", render: function (item, type, row) {
                return "<span>" + item.ID + "</span>" +
                "<input  type='text' size ='3' value='" + item.ID + "' style='display:none' />";

            }
        },

        {
            "data": null, "className": "IC", render: function (item, type, row) {
                return "<span>" + item.ID_CLASSIFICATION + "</span>" +
                "<input size ='5' type='text' value='" + item.ID_CLASSIFICATION + "' style='display:none' />";
            }
        },
		{
		    "data": null, "className": "PG", render: function (item, type, row) {
		        return "<span>" + item.PIPE_GRADE + "</span>" +
                "<input size ='5' type='text' value='" + item.PIPE_GRADE + "' style='display:none' />";
		    }
		},
		{
		    "data": null, "className": "NPS", render: function (item, type, row) {
		        return "<span>" + item.NPS + "</span>" +
                "<input size ='3' type='text' value='" + item.NPS + "' style='display:none' />";
		    }
		},
		{
		    "data": null, "className": "MCP", render: function (item, type, row) {
		        var x = item.MATERIAL_COST_PERMETER;
				
				//if ( x == null)
				//{
				//	x = 0;
				//}
		        //x = x.toString();
		        //var lastThree = x.substring(x.length - 3);
		        //var otherNumbers = x.substring(0, x.length - 3);
		        //if (otherNumbers != '')
		        //    lastThree = ',' + lastThree;
		        //var res = "Rp " + otherNumbers.replace(/\B(?=(\d{2})+(?!\d))/g, ",") + lastThree;
		        //return "<span>" + res + "</span>" +
		        var Rupiah = accounting.formatMoney(x, "Rp ", 2, ".", ",");
		        return "<span>" + Rupiah + "</span>" +
                "<input size ='10' type='text' value='" + item.MATERIAL_COST_PERMETER + "' style='display:none' />";
		    }
		},
		{
		    "data": null, "className": "BMC", render: function (item, type, row) {
		    var x = item.BASE_MATERIAL_COST;
				
				//if ( x == null)
				//{
				//	x = 0;
				//}
		        //x = x.toString();
		        //var lastThree = x.substring(x.length - 3);
		        //var otherNumbers = x.substring(0, x.length - 3);
		        //if (otherNumbers != '')
		        //    lastThree = ',' + lastThree;
		        //var res = "Rp " + otherNumbers.replace(/\B(?=(\d{2})+(?!\d))/g, ",") + lastThree;
		        //return "<span>" + res + "</span>" +

		    var Rupiah = accounting.formatMoney(x, "Rp ", 2, ".", ",");
		    return "<span>" + Rupiah + "</span>" +

                "<input  type='text' size ='10' value='" + item.BASE_MATERIAL_COST + "' style='display:none' />";
		    }
		},
		{
		    "data": null, "className": "CC", render: function (item, type, row) {

		        var x = item.CONSTRUCTION_COST;
				
				//if ( x == null)
				//{
				//	x = 0;
				//}
		        //x = x.toString();
		        //var lastThree = x.substring(x.length - 3);
		        //var otherNumbers = x.substring(0, x.length - 3);
		        //if (otherNumbers != '')
		        //    lastThree = ',' + lastThree;
		        //var res = "Rp " + otherNumbers.replace(/\B(?=(\d{2})+(?!\d))/g, ",") + lastThree;
		        //return "<span>" + res + "</span>" +

		        var Rupiah = accounting.formatMoney(x, "Rp ", 2, ".", ",");
		        return "<span>" + Rupiah + "</span>" +
                "<input  type='text' size ='10' value='" + item.CONSTRUCTION_COST + "' style='display:none' />";
		    }
		},
		{
		    "data": null, "className": "BCC", render: function (item, type, row) {
				
				
				var x = item.BASE_CONSTRUCTION_COST;
				
				//if ( x == null)
				//{
				//	x = 0;
				//}
		        //x = x.toString();
		        //var lastThree = x.substring(x.length - 3);
		        //var otherNumbers = x.substring(0, x.length - 3);
		        //if (otherNumbers != '')
		        //    lastThree = ',' + lastThree;
		        //var res = "Rp " + otherNumbers.replace(/\B(?=(\d{2})+(?!\d))/g, ",") + lastThree;
		        //return "<span>" + res + "</span>" +

		      
				var Rupiah = accounting.formatMoney(x, "Rp ", 2, ".", ",");
				return "<span>" + Rupiah + "</span>" +
				
				
                "<input  type='text' size ='10' value='" + item.BASE_CONSTRUCTION_COST + "' style='display:none' />";
		    }
		},

          {
              "data": null,
              "className": "center",
              "defaultContent": "<a class='Edit' href='javascript:;'>Edit</a>"
                + " <a class='Update' href='javascript:;' style='display:none'>Update</a>"
                + " <a class='Cancel' href='javascript:;' style='display:none'>Cancel</a>"
                //+ " <a class='Delete' href='javascript:;'>Delete</a>"
              //data: null, render: function (data, type, row) {
              //    // Combine the first and last names into a single table field
              //    return data.CustomerID + ' ' + data.Nama;
              //}
          }
        ],
        "createdRow": function (row, data, index) {
            $('td', row).eq(0).addClass("hidetd");
        },

    });

  

});

$("body").on("click", "#btnAddPipeCost", function () {
   

    var pl_config_pipeline_cost = {};  
    pl_config_pipeline_cost.ID_CLASSIFICATION = $("#txtIdClassification").val();
    pl_config_pipeline_cost.PIPE_GRADE = $("#txtPipeGrade").val();
    pl_config_pipeline_cost.NPS = $("#txtNPS1").val();
    pl_config_pipeline_cost.MATERIAL_COST_PERMETER = $("#txtMaterialCostPermeter").val();
    pl_config_pipeline_cost.BASE_MATERIAL_COST = $("#txtBMC").val();
    pl_config_pipeline_cost.CONSTRUCTION_COST = $("#txtCC").val();
    pl_config_pipeline_cost.BASE_CONSTRUCTION_COST = $("#txtBCC").val();
	
	debugger;
   
    $.ajax({
        type: "POST",
        url: url_api_set_pipeCost,
        data: JSON.stringify(pl_config_pipeline_cost),
        //data: '{ID_CLASSIFICATION: "' + txtIdClassification.val() + '" , PIPE_GRADE: "' + txtPipeGrade.val() + '", NPS: "' + txtNPS.val() + '" , MATERIAL_COST_PERMETER: "' + txtMaterialCostPermeter.val() + '" , BASE_MATERIAL_COST: "' + txtBaseMaterialCost.val() + '", CONSTRUCTION_COST: "' + txtConstructionCost.val() + '" , BASE_CONSTRUCTION_COST: "' + txtBaseConstructionCost.val() + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            $(function () {
                $('#pipeCostModal').modal('toggle');
            });
            //window.location.href = "/home/Settings";
            alert("Data Saved");
            $('#tblpipeCost').DataTable().ajax.reload(null, false);
        }
    });
});

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////Edit event handler.
$("body").on("click", "#tblpipeCost .Edit", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            $(this).find("input").show();
            $(this).find("span").hide();
        }
    });
    row.find(".Update").show();
    row.find(".Cancel").show();
    row.find(".Delete").hide();
    $(this).hide();



});

//Update event handler.
$("body").on("click", "#tblpipeCost .Update", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            var span = $(this).find("span");
            var input = $(this).find("input");
            span.html(input.val());
            span.show();
            input.hide();
        }
    });
    row.find(".Edit").show();
    row.find(".Delete").show();
    row.find(".Cancel").hide();
    $(this).hide();


    var pl_config_pipeCost = {};
    pl_config_pipeCost.ID = row.find(".ID").find("span").html();
    pl_config_pipeCost.ID_CLASSIFICATION = row.find(".IC").find("span").html();
    pl_config_pipeCost.PIPE_GRADE = row.find(".PG").find("span").html();
	pl_config_pipeCost.NPS = row.find(".NPS").find("span").html();
    pl_config_pipeCost.MATERIAL_COST_PERMETER = row.find(".MCP").find("span").html();
    pl_config_pipeCost.BASE_MATERIAL_COST = row.find(".BMC").find("span").html();
	pl_config_pipeCost.CONSTRUCTION_COST = row.find(".CC").find("span").html();
    pl_config_pipeCost.BASE_CONSTRUCTION_COST = row.find(".BCC").find("span").html();
   



    $.ajax({
        type: "Put",
        url: url_api_set_pipeCost,
        data: JSON.stringify(pl_config_pipeCost),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });
});
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Cancel event handler.
$("body").on("click", "#tblpipeCost .Cancel", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            var span = $(this).find("span");
            var input = $(this).find("input");
            input.val();
            span.show();
            input.hide();
        }
    });
    row.find(".Edit").show();
    row.find(".Delete").show();
    row.find(".Update").hide();
    $(this).hide();
});

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


//Delete event handler.
$("body").on("click", "#tblpipeCost .Delete", function () {

    if (confirm("Do you want to delete this row?")) {
        var row = $(this).closest("tr");
        var pl_config_pipeCost = {};
        pl_config_pipeCost.ID = row.find(".ID").find("span").html();
        $.ajax({
            type: "Delete",
            url: url_api_set_pipeCost,
            data: JSON.stringify(pl_config_pipeCost),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                row.remove();
                $('#tblpipeCost').DataTable().ajax.reload(null, false);
            }
        });
    }
});


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

var table_user_role;

$(document).ready(function () {

    table_user_role = $('#tblUserRole').DataTable({
        "iDisplayLength": 5,
        "bStateSave": true,
        "aLengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
        "ajax": {
            "url": url_api_user_role,
            "dataSrc": ''
        },
        "columns": [
        {
            "data": null, "className": "ID", render: function (item, type, row) {
                return "<span>" + item.ID + "</span>" +
                "<input type='text' value='" + item.ID + "' style='display:none' />";

            }
        },

        {
            "data": null, "className": "userName", render: function (item, type, row) {
                return "<span>" + item.USER_NAME + "</span>" ;
              
            }
        },
		{
		    "data": null, "className": "userRole", render: function (item, type, row) {
		        return "<span>" + item.USER_ROLE + "</span>" +
                //"<input type='text' value='" + item.USER_ROLE + "' style='display:none' />"
				 "<select style='display:none' id='userRoleId' onchange='javascript: initialize(this.value);'> "+
                 "<option value='nimoadmin' selected>nimoadmin</option><option value='nimouser' selected>nimouser</option>";
		    }
		},

          {
              "data": null,
              "className": "center",
              "defaultContent": "<a class='Edit' href='javascript:;'>Edit</a>"
                + " <a class='Update' href='javascript:;' style='display:none'>Update</a>"
                + " <a class='Cancel' href='javascript:;' style='display:none'>Cancel</a>"
                + " <a class='Delete' href='javascript:;'>Delete</a>"
              //data: null, render: function (data, type, row) {
              //    // Combine the first and last names into a single table field
              //    return data.CustomerID + ' ' + data.Nama;
              //}
          }
        ],
        "createdRow": function (row, data, index) {
            $('td', row).eq(0).addClass("hidetd");
        },

    });

});

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



$("body").on("click", "#btnAddUserRole", function () {
    var txtUserName = $("#txtUserName");
    var ddlUserRole = $("#ddlUserRole").val();;
   

    $.ajax({
        type: "POST",
        url: url_api_user_role,
        data: '{USER_NAME: "' + txtUserName.val() + '" , USER_ROLE: "' + ddlUserRole + '"  }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            $(function () {
                $('#userRoleModal').modal('toggle');
            });
            
            alert("Data Saved");
            $('#tblUserRole').DataTable().ajax.reload(null, false);
        }
    });
});

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////Edit event handler.
$("body").on("click", "#tblUserRole .Edit", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("select").length > 0) {
            $(this).find("select").show();
            $(this).find("span").hide();
        }

        
    });
    row.find(".Update").show();
    row.find(".Cancel").show();
    row.find(".Delete").hide();
    $(this).hide();



});

//Update event handler.
$("body").on("click", "#tblUserRole .Update", function () {
    var row = $(this).closest("tr");
    
    $("td", row).each(function () {
        if ($(this).find("select").length > 0) {
            var span = $(this).find("span");
            var input = $(this).find("select");		  
            span.html(input.val());		
            span.show();
            input.hide();

        }
    });
    row.find(".Edit").show();
    row.find(".Delete").show();
    row.find(".Cancel").hide();
    $(this).hide();


    var pl_config_user_role = {};
    pl_config_user_role.ID = row.find(".ID").find("span").html();
    pl_config_user_role.USER_NAME = row.find(".userName").find("span").html();
    pl_config_user_role.USER_ROLE = row.find(".userRole").find("span").html();



    $.ajax({
        type: "Put",
        url: url_api_user_role,
        data: JSON.stringify(pl_config_user_role),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });
});
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Cancel event handler.
$("body").on("click", "#tblUserRole .Cancel", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("select").length > 0) {
            var span = $(this).find("span");
            var input = $(this).find("select");
            input.val(span.html());
            span.show();
            input.hide();
        }
    });
    row.find(".Edit").show();
    row.find(".Delete").show();
    row.find(".Update").hide();
    $(this).hide();
});

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


//Delete event handler.
$("body").on("click", "#tblUserRole .Delete", function () {
    if (confirm("Do you want to delete this row?")) {
        var row = $(this).closest("tr");
        var pl_config_user_role = {};
        pl_config_user_role.ID = row.find(".ID").find("span").html();
        $.ajax({
            type: "Delete",
            url: url_api_user_role,
            data: JSON.stringify(pl_config_user_role),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                row.remove();
                $('#tblUserRole').DataTable().ajax.reload(null, false);
            }
        });
    }
});




