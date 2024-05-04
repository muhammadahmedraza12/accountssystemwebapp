import "../src/App.css"; 
import axios from "axios";
import { useEffect, useState } from "react";



function MasterAC() {
  const [id, setId] = useState("");
  const [MastrAccount, setMastrAccount] = useState("");
  const [Fid, setFid] = useState("");
  const [Status, setStatus] = useState("");
  const [FixedAccount, setFixedAccount] = useState("");
  const [MasterAccount, setMasterAccount] = useState([]);

  useEffect(() => {
    (async () => await Load())();
  }, []);

  async function Load() {
    const res = await axios.get("https://localhost:44381/MasterAC/GetAllMasterAC");
    setMasterAccount(res.data);
  }

  async function save(event) {
    event.preventDefault();
    try {
      await axios.post("https://localhost:44381/MasterAC/SaveMasterAc", {
        MastrAccount: MastrAccount,
        Status: Status,
        Fid: Fid,
        FixedAccount: FixedAccount,
      });
      alert("Registration Successfully");
      setId("");
      setMastrAccount("");
      setFid("");
      setStatus("");
      setFixedAccount("");
      Load();
    } catch (err) {
      alert(err);
    }
  }

  async function edit(data) {
    setMastrAccount(data.MastrAccount);
    setFid(data.Fid);
    setStatus(data.Status);
    setId(data.id);
  }

  async function Delete(id) {
    await axios.delete("https://localhost:44381/MasterAC/DeleteMasterAc/" + id);
    alert("Deleted Successfully");
    setId("");
    setMastrAccount("");
    setFid("");
    setStatus("");
    setFixedAccount("");
    Load();
  }

  async function update(event) {
    event.preventDefault();
    try {
      await axios.patch(
        "https://localhost:44381/MasterAC/MasterACUpdate/" +
          (MasterAccount.find((u) => u.id === id).id || id),
        {
          id: id,
          MastrAccount: MastrAccount,
          Status: Status,
          Fid: Fid,
          FixedAccount: FixedAccount,
        }
      );
      alert("Account Detail Update");
      setId("");
      setMastrAccount("");
      setFixedAccount("");
      setStatus("");
      setFid("");
      Load();
    } catch (err) {
      alert(err);
    }
  }

  return (
    <div className="container">
      <h1 className="chart-heading">MASTER ACCOUNT</h1>
      <form>

      <div className="form-row">
          <div className="form-group col-md-6">
          {/* <input
            type="text"
            className="form-control"
            id="id"
            hidden
            value={id}
            onChange={(event) => {
              setId(event.target.value);
            }}
          /> */}
          
          <label>TurnOver Account</label>
          <input 
            type="text"
            className="form-control"
            id="MastrAccount"
            value={MastrAccount}
            onChange={(event) => {
              setMastrAccount(event.target.value);
            }}
          />
        
        </div>

        <div style={{marginLeft:"600px", marginTop:"-115px"}} className="form-group mb-3">
          <label htmlFor="title">Category Account</label>
          <select
            className="form-control"
            value={Fid}
            onChange={(event) => {
              setFid(event.target.value);
            }}
          >
            <option value={0}>--Select Account Type</option>
            {MasterAccount.map((data) => (
              <option value={data.Fid} key={data.Fid}>
                {data.FixedAccount}
              </option>
            ))}
          </select>
        </div>

        <div  className="form-group">
          <label>Status</label>
          <input
            type="text"
            className="form-control"
            id="Status"
            value={Status}
            onChange={(event) => {
              setStatus(event.target.value);
            }}
          />
          </div>
        </div>
        <div>
          <button className="btn btn-success mt-4" onClick={save}>
            Register
          </button>
          <button className="btn btn-primary mt-4" onClick={update}>
            Update
          </button>
        </div>
      </form>
      <br></br>
      <table style={{borderRadius:"20px"}} className="table bg-white " align="center">
        <thead className="thead-dark">
          <tr>
            <th scope="col">TurnOver Account</th>
            <th scope="col">Category Account</th>
            <th scope="col">Status</th>
            <th scope="col">Option</th>
          </tr>
        </thead>
        <tbody>
          {MasterAccount.map((data) => (
            <tr key={data.id}>
              <td>{data.MastrAccount}</td>
              <td>{data.FixedAccount}</td>
              <td>{data.Status}</td>
              <td>
                <button
                  type="button"
                  className="btn btn-primary"
                  onClick={() => edit(data)}
                >
                  Edit
                </button>
                <button
                  type="button"
                  className="btn btn-danger"
                  onClick={() => Delete(data.id)}
                >
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default MasterAC;

