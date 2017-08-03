/// <binding AfterBuild='moduleCopy, copyModuleDependencies' />

var gulp = require('gulp');
var rimraf = require('rimraf');
var newer = require('gulp-newer');
var gutil = require('gulp-util');
var fs = require('fs')
var path = require('path');
var rename = require('gulp-rename');


gulp.task('copyModuleDependencies', function (cd) {
    gulp.src('../*Module/bin/Debug/*.dll')
        .pipe(rename({ dirname: '' }))
        .pipe(gulp.dest("bin/Debug/"))
});

gulp.task('moduleCopy', function (cb) {
    gulp.src('../*Module/bin/Debug/*.Module.dll')
        .pipe(newer("bin/Debug/Modules/"))
        .pipe(rename({ dirname: '' }))
        .pipe(gulp.dest("bin/Debug/Modules/"))
});