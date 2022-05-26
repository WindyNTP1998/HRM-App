import React, { useEffect } from 'react';
import { Outlet, useNavigate } from 'react-router-dom';
import './Admin.css';
import Sidebar from './sidebar/Sidebar';

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
		<div className="container">
			<Sidebar />
			<Outlet />
		</div>
	);
}
