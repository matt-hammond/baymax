/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var sass = require('gulp-sass');

gulp.task('sass-compile', function () {
    gulp.src('./submodules/govuk-elements/public/sass/*.scss')
        .pipe(sass({ includePaths: ['./submodules/govuk_frontend_toolkit/stylesheets/', './submodules/govuk-elements/public/sass/'] }))
        .pipe(gulp.dest('./wwwroot/public/stylesheets'));
});

gulp.task('copy-govuk_frontend_toolkit', function () {
    gulp.src('./submodules/govuk_frontend_toolkit/javascripts/**/*')
        .pipe(gulp.dest('./wwwroot/public/javascripts'));
    gulp.src('./submodules/govuk_frontend_toolkit/images/**/*')
    .pipe(gulp.dest('./wwwroot/public/images'));
});

gulp.task('copy-govuk_elements', function () {
    gulp.src('./submodules/govuk-elements/public/javascripts/**/*')
        .pipe(gulp.dest('./wwwroot/public/javascripts'));
    gulp.src('./submodules/govuk-elements/public/images/**/*')
    .pipe(gulp.dest('./wwwroot/public/images'));
});

gulp.task('copy-nhs_template', function () {
    gulp.src('./submodules/govuk_template/source/assets/images/**/*').pipe(gulp.dest('./wwwroot/public/images'));

    gulp.src('./submodules/govuk_template/source/assets/stylesheets/*.scss')
    .pipe(sass({ includePaths: ['./submodules/govuk_template/source/assets/stylesheets/', './submodules/govuk_frontend_toolkit/stylesheets'] }))
        .pipe(gulp.dest('./wwwroot/public/stylesheets'));

});

gulp.task('default', [
    'sass-compile',
    'copy-govuk_frontend_toolkit',
        'copy-govuk_elements',
     'copy-nhs_template'
]);

gulp.task('watch-sass', function () {
    gulp.watch('./node_modules/*.scss', ['sass-compile']);
});