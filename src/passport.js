var passport = require('passport'),
    LocalStrategy = require('passport-local').Strategy;

module.exports = function(authentication) {
    passport.serializeUser(authentication.serializeUser);

    passport.deserializeUser(authentication.deserializeUser);

    passport.use(new LocalStrategy(authentication.login));

    return passport;
};

module.exports.$inject = ['authentication'];
