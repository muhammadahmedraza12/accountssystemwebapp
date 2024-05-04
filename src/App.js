import React from "react";
import { BrowserRouter as Router, NavLink, Routes, Route } from "react-router-dom";
import MasterAccount from "./MasterAccount";
import AddMasterAC from "./AddMasterAC";
import MasterAC from "./MasterAC";
import Master from "./Master";
import ChartoFAccount from "./ChartoFAccount";
import CompanyLogo from "./navlogo.png";
import UserImage from "../src/userimg.jpg"; // Import your user image
import "./App.css"; // Import the CSS file for styling
import PaymentVoucher from "./PaymentVocher";

class App extends React.Component {
  render() {
    const logoStyle = {
      marginRight: "20px",
    };

    const userImageStyle = {
      width: "50px",
      height: "50px",
      borderRadius: "50%",
      backgroundColor: "lightgray", // Set a background color
    };

    return (
      <Router>
        <div className="app-container">
          <nav className="navbar navbar-expand-lg bg-body-tertiary bg-dark">
            <div className="container-fluid">
              <div>
                <NavLink style={logoStyle}>
                  <img src={CompanyLogo} alt="Company Logo" width="50" height="50" style={{marginRight:"50px"}} to="/MasterAC" />
                </NavLink>
              </div>
              <button
                className="navbar-toggler"
                type="button"
                data-bs-toggle="collapse"
                data-bs-target="#navbarSupportedContent"
                aria-controls="navbarSupportedContent"
                aria-expanded="false"
                aria-label="Toggle navigation"
              >
                <span className="navbar-toggler-icon"></span>
              </button>
              <div className="collapse navbar-collapse" id="navbarSupportedContent">
                <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                  <li className="nav-item">
                    <NavLink className="nav-link text-white" to="/ChartoFAccount">
                      CHART OF ACCOUNT
                    </NavLink>
                  </li>
                  <li className="nav-item">
                    <NavLink className="nav-link text-white" to="/MasterAC">
                      MASTER ACCOUNT
                    </NavLink>
                  </li>
                  <li className="nav-item">
                    <NavLink className="nav-link text-white" to="/PaymentVoucher">
                      PAYMENT VOUCHER
                    </NavLink>
                  </li>
                </ul>
               
                <div className="d-flex align-items-center ml-auto"> {/* Use flexbox to align the user image on the right */}
                  <img src={UserImage} alt="User" style={userImageStyle} />
                </div>
              </div>
            </div>
          </nav>

          <Routes>
            <Route path="/" element={<MasterAC />} />
            <Route path="/Master" element={<Master />} />
            <Route path="/MasterAC" element={<MasterAC />} />
            <Route path="/MasterAccount" element={<MasterAccount />} />
            <Route path="/MasterAccount/AddMasterAC/:id?" element={<AddMasterAC />} />
            <Route path="/ChartoFAccount" element={<ChartoFAccount />} />
            <Route path="/PaymentVoucher" element={<PaymentVoucher />} />
          </Routes>

          <br />
          <footer className="bg-dark text-white text-center py-2">
            <div className="container">
              <div className="row">
                <div className="col-md-1 text-left">
                  <a href="#">
                    <img src={CompanyLogo} alt="Company Logo" width="50" height="50" />
                  </a>
                </div>
                <div style={{ marginTop: "-35px" }}>
                  &copy; 2023 Made By M.Ahmed Raza
                </div>
              </div>
            </div>
          </footer>
        </div>
      </Router>
    );
  }
}

export default App;
