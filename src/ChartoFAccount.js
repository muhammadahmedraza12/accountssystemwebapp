import axios from "axios";
import { useEffect, useState } from "react";
import "../src/App.css"; 

function ChartoFAccount() {
  const [id, setId] = useState("");
  const [Mid, setMid] = useState(0);
  const [AccountName, setAccountName] = useState("");
  const [TurnOverAc, setTurnOverAc] = useState("");
  const [RefNo, setRefNo] = useState("");
  const [Date, setDate] = useState("");
  const [Debit, setDebit] = useState("");
  const [Credit, setCredit] = useState("");
  const [ChartFAccount, setChartFAccount] = useState([]);
  const [MasterAccount, setMasterAccount] = useState([]);

  useEffect(() => {
    (async () => await Load())();
  }, []);

  useEffect(() => {
    (async () => await Loading())();
  }, []);

  async function Load() {
    const res = await axios.get("https://localhost:44381/ChartOfAC/GetAllChartFACC");
    setChartFAccount(res.data);
  }

  async function Loading() {
    const res = await axios.get("https://localhost:44381/MasterAC/GetAllMasterAC");
    setMasterAccount(res.data);
  }

  async function save(event) {
    event.preventDefault();
    try {
      await axios.post("https://localhost:44381/ChartOfAC/SaveChartFAc", {
        AccountName: AccountName,
        TurnOverAc: TurnOverAc,
        Date: Date,
        Debit: Debit,
        Credit: Credit,
        Mid: Mid,
      });
      alert("Registration Successful");
      setId("");
      setMid("");
      setAccountName("");
      setTurnOverAc("");
      setRefNo("");
      setDate("");
      setDebit("");
      setCredit("");
      Load();
    } catch (err) {
      alert(err);
    }
  }

  async function edit(data) {
    setAccountName(data.AccountName);
    setMid(data.Mid);
    setRefNo(data.RefNo);
    setId(data.id);
    setDate(data.Date);
    setDebit(data.Debit);
    setCredit(data.Credit);
  }

  async function Delete(id) {
    await axios.delete("https://localhost:44381/ChartOfAC/DeleteChartAc/" + id);
    alert("Deleted Successfully");
    setId("");
    setMid("");
    setAccountName("");
    setTurnOverAc("");
    setRefNo("");
    setDate("");
    setDebit("");
    setCredit("");
    Load();
  }

  async function update(event) {
    event.preventDefault();
    try {
      await axios.patch(
        "https://localhost:44381/ChartOfAC/ChartACUpdate/" +
          (ChartFAccount.find((u) => u.id === id).id || id),
        {
          id: id,
          AccountName: AccountName,
          TurnOverAc: TurnOverAc,
          RefNo: RefNo,
          Date: Date,
          Debit: Debit,
          Credit: Credit,
          Mid: Mid,
        }
      );
      alert("Account Detail Updated");
      setId("");
      setMid("");
      setAccountName("");
      setTurnOverAc("");
      setRefNo("");
      setDate("");
      setDebit("");
      setCredit("");
      Load();
    } catch (err) {
      alert(err);
    }
  }

  return (
    <div className="container">
      <h1 className="chart-heading">Chart of Accounts</h1>
      <form>
        <div className="form-row">
          <div className="form-group col-md-6">
            <label>Account Name</label>
            <input
              type="text"
              className="form-control"
              id="MastrAccount"
              value={AccountName}
              onChange={(event) => {
                setAccountName(event.target.value);
              }}
            />
          </div>
          <div style={{marginLeft:"600px", marginTop:"-115px"}} className="form-group col-md-6">
            <label>TurnOver Account</label>
            <select
              className="form-control"
              value={Mid}
              onChange={(event) => {
                setMid(event.target.value);
              }}
            >
              <option value={0}>--Select Account Type</option>
              {MasterAccount.map((data) => (
                <option value={data.id} key={data.id}>
                  {data.MastrAccount}
                </option>
              ))}
            </select>
          </div>
          <div className="form-group col-md-6">
            <label>Date</label>
            <input
              type="date"
              className="form-control"
              id="Date"
              value={Date}
              onChange={(event) => {
                setDate(event.target.value);
              }}
            />
          </div>
          <div style={{marginLeft:"600px", marginTop:"-115px"}}  className="form-group col-md-6">
            <label>Debit</label>
            <input
              type="number"
              className="form-control"
              id="Debit"
              value={Debit}
              onChange={(event) => {
                setDebit(event.target.value);
              }}
            />
          </div>
          <div style={{marginRight:"-50px"}} className="form-group">
            <label>Credit</label>
            <input
              type="number"
              className="form-control"
              id="Credit"
              value={Credit}
              onChange={(event) => {
                setCredit(event.target.value);
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
      <table style={{borderRadius:"20px"}} className="table bg-white" align="center">
        <thead className="thead-dark">
          <tr>
            <th scope="col">AC Code</th>
            <th scope="col">Date</th>
            <th scope="col">Master A/C</th>
            <th scope="col">Account Name</th>
            <th scope="col">Debit</th>
            <th scope="col">Credit</th>
            <th scope="col">Option</th>
          </tr>
        </thead>
        <tbody>
          {ChartFAccount.map((data) => (
            <tr key={data.id}>
              <td>{data.RefNo}</td>
              <td>{data.Date}</td>
              <td>{data.TurnOverAc}</td>
              <td>{data.AccountName}</td>
              <td>{data.Debit}</td>
              <td>{data.Credit}</td>
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

export default ChartoFAccount;
