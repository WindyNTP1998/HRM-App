import React, { useEffect } from 'react';
import { Navigate, useNavigate } from 'react-router-dom';

export default function Admin() {
	const navigate = useNavigate();
	const checkLocalStore = () => {
		if (!localStorage.getItem('accessToken')) {
			navigate('/home');
		}
	};

	useEffect(() => {
		checkLocalStore();
	}, []);

	return (
		<div>
			<h1>Admin Page</h1>
		</div>
	);
}
