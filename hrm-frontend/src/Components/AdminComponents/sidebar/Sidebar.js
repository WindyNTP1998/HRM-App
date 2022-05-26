import React from 'react';
import './Sidebar.css';
import { SupervisorAccountOutlined, LineStyleSharp, WorkspacesSharp } from '@mui/icons-material';

import { Link } from 'react-router-dom';

function Sidebar() {
	return (
		<div className="sidebar">
			<div className="sidebarWrapper">
				<div className="sidebarMenu">
					<h3 className="sidebarTitle">Admin Dashborad</h3>
					<ul className="sidebarList">
						<Link to="/admin" className="link">
							<li className="sidebarListItem">
								<LineStyleSharp className="sidebarIcon" />
								Home
							</li>
						</Link>
						<Link to="userlist" className="link">
							<li className="sidebarListItem">
								<SupervisorAccountOutlined className="sidebarIcon" />
								Account
							</li>
						</Link>
						<li className="sidebarListItem">
							<WorkspacesSharp className="sidebarIcon" />
							Organization
						</li>
					</ul>
				</div>
			</div>
		</div>
	);
}

export default Sidebar;
