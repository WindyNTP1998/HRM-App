import React, { useEffect, useState } from 'react';
import './Nav.css';
import SettingsIcon from '@mui/icons-material/Settings';
import LogoutIcon from '@mui/icons-material/Logout';

export default function Nav() {
	const [visible, setVisible] = useState(true);

	useEffect(() => {}, []);

	return (
		// <div className="topnav">

		// </div>
		<div className="topbar">
			<div className="topbarWraper">
				<div className="topLeft">
					<span className="logo">Orient HRM</span>
					<div className="topnav">
						<a href="/">Home</a>
						<a href="/login">Login</a>
						<a href="/admin">Admin</a>
						<a href="/about">About</a>
					</div>
				</div>
				{visible && (
					<div className="topRight">
						<div className="topbarIconContainer">
							<SettingsIcon />
						</div>
						<div className="topbarIconContainer">
							<LogoutIcon />
						</div>
						<img
							src="https://joeschmoe.io/api/v1/random"
							alt=""
							className="topAvatar"
						/>
					</div>
				)}
			</div>
		</div>
	);
}
