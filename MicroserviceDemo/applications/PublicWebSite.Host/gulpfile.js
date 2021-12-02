"use strict";

var gulp = require("gulp"),
    path = require('path'),
    copyResources = require('./node_modules/@abp/aspnetcore.mvc.ui/gulp/copy-resources.js');

gulp.task('default', async function () {
    await copyResources(path.resolve('./'));
});