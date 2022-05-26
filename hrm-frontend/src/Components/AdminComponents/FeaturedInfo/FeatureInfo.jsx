import './FeatureInfo.css';
import PersonIcon from '@mui/icons-material/Person';

export default function FeatureInfo() {
	return (
		<div className="featured">
			<div className="featuredItem">
				<span className="featuredTitle">NhanVien:</span>
				<div className="featuredUserContainer">
					<span className="featuredUser">
						6 <PersonIcon />
					</span>
				</div>
				<span className="featuredSub">Tong so nhan vien OSD</span>
			</div>
			<div className="featuredItem">
				<span className="featuredTitle">NhanVien:</span>
				<div className="featuredUserContainer">
					<span className="featuredUser">
						6 <PersonIcon />
					</span>
				</div>
				<span className="featuredSub">Tong so nhan vien OSD</span>
			</div>
			<div className="featuredItem">
				<span className="featuredTitle">NhanVien:</span>
				<div className="featuredUserContainer">
					<span className="featuredUser">
						6 <PersonIcon />
					</span>
				</div>
				<span className="featuredSub">Tong so nhan vien OSD</span>
			</div>
		</div>
	);
}
