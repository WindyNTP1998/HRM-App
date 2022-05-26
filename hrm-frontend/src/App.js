import './App.css';

import React from 'react';
import { BrowserRouter as Router, Link, Route, Routes, Navigate } from 'react-router-dom';
import Admin from './Components/AdminComponents/Admin';
import Login from './Components/LoginComponents/Login';
import Nav from './Components/Nav/Nav.js';
import Home from './Components/HomeComponent/Home';
import UserList from './Components/AdminComponents/UserList/UserList';
import AdminHome from './Components/AdminComponents/AdminHome/AdminHome';

function App() {
	return (
		<>
			<header className="App-header">
				<Nav />
			</header>

			<Router>
				<Routes>
					<Route path="/admin" element={<Admin />}>
						<Route index element={<AdminHome />}></Route>
						<Route path="userlist" element={<UserList />}></Route>
					</Route>
					<Route path="/login" element={<Login />}></Route>
					<Route path="/home" element={<Home />}></Route>
					<Route path="/" exact element={<Home />}></Route>
				</Routes>
			</Router>

			{/* //<footer>Nguyen Thanh Phong</footer> */}
		</>
	);
}

export default App;
