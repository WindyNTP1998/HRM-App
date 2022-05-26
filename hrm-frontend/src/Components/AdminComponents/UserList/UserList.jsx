import React, { useEffect, useState } from 'react';
import { DataGrid } from '@mui/x-data-grid';
import axios from 'axios';
import DeleteOutlinedIcon from '@mui/icons-material/DeleteOutlined';
import './UserList.css';

export default function UserList() {
	const [isLoading, setIsLoading] = useState(false);
	const [gridData, setGridData] = useState([]);

	const columns = [
		{ field: 'manv', headerName: 'OSD ID', width: 90, identity: true },
		{
			field: 'mavp',
			headerName: 'Office',
			width: 100,
			editable: false,
		},
		{
			field: 'mapb',
			headerName: 'Department',
			width: 100,
			editable: false,
		},
		{
			field: 'macv',
			headerName: 'Job Title',
			width: 100,
			editable: false,
		},
		{
			field: 'hoten',
			headerName: 'Name',
			width: 200,
			editable: false,
		},
		{
			field: 'email',
			headerName: 'Name',
			width: 250,
			editable: false,
		},
		{
			field: 'action',
			headerName: 'Action',
			width: 150,
			renderCell: (params) => {
				return (
					<>
						<button className="userListEdit">Edit</button>
						&nbsp;
						<DeleteOutlinedIcon
							className="userListDelete"
							onClick={() => console.log('Delete' + params.row.manv)}
						/>
					</>
				);
			},
		},
	];

	const loadUserList = async () => {
		setIsLoading(true);
		await axios.get('https://localhost:7094/api/user/NhanVien/GetAll').then((res) => {
			setGridData(res.data);
			setIsLoading(false);
		});
	};

	useEffect(() => {
		loadUserList();
	}, []);
	console.log(gridData);
	return (
		<div className="userList">
			<DataGrid
				rows={gridData}
				disableSelectionOnClick
				columns={columns}
				getRowId={(row) => row.manv}
				pageSize={8}
				disableColumnSelector
			/>
		</div>
	);
}
