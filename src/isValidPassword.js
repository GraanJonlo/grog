var bcrypt = require('bcrypt-nodejs');

var isValidPassword = function() {
	return {
		validate: function(user, password) {
			return bcrypt.compareSync(password, user.password);
		}
	};
};

isValidPassword.$inject = [];

module.exports = isValidPassword;
