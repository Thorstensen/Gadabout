// include plug-ins
var gulp = require('gulp');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var del = require('del');

gulp.task('copy', function () {
    gulp.src('./src/templates/index.html')
        .pipe(gulp.dest('./public/'));
});
