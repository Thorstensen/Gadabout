/// <binding AfterBuild='moduleCopy' />
var gulp = require('gulp');
var rimraf = require('rimraf');
var newer = require('gulp-newer');


gulp.task('moduleCopy', function (cb) {
    gulp.src("bin/Debug/*.Module.dll")
        .pipe(newer("bin/Debug/Modules/"))    
        .pipe(gulp.dest("bin/Debug/Modules/"))
});