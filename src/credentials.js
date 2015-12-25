var bcrypt = require('bcrypt-nodejs');

var credentials = function() {
	return {
		validatePassword: function(user, password) {
			return bcrypt.compareSync(password, user.password);
		}
	};
};

credentials.$inject = [];

module.exports = credentials;
