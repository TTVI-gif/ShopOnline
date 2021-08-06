/*
Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
For licensing, see license.txt or http://cksource.com/ckfinder/license
*/

CKFinder.customConfig = function( config )
{
    config.filebrowserBrowseUrl = "/ckfinder/ckfinder.html";
    config.filebrowserImageBrowseUrl = "/ckfinder/ckfinder.html?type=Images";
    config.filebrowserFlashBrowseUrl = "/ckfinder/ckfinder.html?type=Flash";
    config.filebrowserUploadUrl = "/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
    config.filebrowserImageUploadUrl = "/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
    config.filebrowserFlashUploadUrl = "/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";

};
