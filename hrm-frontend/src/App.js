import './App.css';

import React from 'react';
import { BrowserRouter as Router, Link, Route, Routes, Navigate, BrowserRouter } from 'react-router-dom';
import Admin from './Components/AdminComponents/Admin';
import Login from './Components/LoginComponents/Login';
import Nav from './Components/Nav/Nav.js';
import Home from './Components/HomeComponent/Home';

function App() {
	return (
		<>
			<header className="App-header">
				<Nav />
			</header>

			<Router>
				<Routes>
					<Route exact path="/admin" element={<Admin />}></Route>
					<Route path="/login" exact element={<Login />}></Route>
					<Route path="/home" exact element={<Home />}></Route>
					<Route path="/" exact element={<Home />}></Route>
				</Routes>
			</Router>

			<footer>Nguyen Thanh Phong</footer>
		</>
	);
}

export default App;
