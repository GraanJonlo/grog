var authentication = function(readModel) {
	return {
		deserializeUser:function(username, cb) {
			readModel.getUser(username)
			.then(function(result) {
				cb(null, result);
			})
			.catch(function(err) {
				cb(err, null);
			});
		},
		serializeUser: function(user, cb) {
			cb(null, user.username);
		}
	};
};

authentication.$inject = ['readModel'];

module.exports = authentication;
