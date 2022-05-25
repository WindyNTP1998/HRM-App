import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import { useFormik, Field } from 'formik';
import { Button, Form, FormGroup, Label, Input, Container } from 'reactstrap';
import './Login.css';

export default function Login() {
	const navigate = useNavigate();

	const formik = useFormik({
		initialValues: {
			username: '',
			password: '',
		},
		onSubmit: (values) => {
			handlerSubmit(values);
		},
	});

	const AdminLogin = (userData) => {
		localStorage.setItem('accessToken', true);
		localStorage.setItem('adminToken', true);
		localStorage.setItem('userData', userData);
		navigate('/admin', { replace: true });
	};

	const UserLogin = (userData) => {
		localStorage.setItem('accessToken', true);
		localStorage.setItem('userData', userData);
		navigate('/home', { replace: true });
	};

	const handlerSubmit = async (value) => {
		const article = { title: 'POST Login' };
		console.log(value);
		await axios({
			method: 'post',
			url: 'https://localhost:7094/api/Login',
			data: value,
		}).then((res) => {
			if (res.status == 200) {
				if (res.data[0].role == 0) {
					AdminLogin(res.data[0]);
				} else {
					UserLogin(res.data[0]);
				}
			}
		});
	};

	return (
		<div className="loginForm">
			<Container className="container">
				<p></p>
				<h1>Đăng nhập</h1>
				<Form className="infoform" onSubmit={formik.handleSubmit}>
					<FormGroup>
						<Label htmlFor="username">UserName:</Label>
						<Input
							type="text"
							id="username"
							name="username"
							value={formik.values.username}
							onChange={formik.handleChange}
							placeholder="Username"
						/>
					</FormGroup>
					<FormGroup>
						<Label htmlFor="password"> Password: </Label>
						<Input
							type="password"
							id="password"
							name="password"
							value={formik.values.password}
							onChange={formik.handleChange}
							placeholder="Enter your password"
						/>
					</FormGroup>
					<FormGroup>
						<Button color="primary" type="submit">
							Login
						</Button>
					</FormGroup>
				</Form>
			</Container>
		</div>
	);
}
