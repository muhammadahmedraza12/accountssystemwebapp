import axios from "axios";
import React, { useEffect, useState } from "react";

function PaymentVoucher() {
  const [RId, setRId] = useState("");
  const [Amount, setAmount] = useState("");
  const [InvoiceNo, setInvoiceNo] = useState("");
  const [Date, setDate] = useState("");
  const [Description, setDescription] = useState("");
  const [Payment, setPayment] = useState([]);

  useEffect(() => {
    Load(); 
  }, []);

  async function Load() {
    try {
      const response = await axios.get("https://localhost:44381/ReceiptMaster/GetAllreciepmaster");
      setPayment(response.data);
    } catch (error) {
      console.error(error);
    }
  }

  async function save(event) {
    
    event.preventDefault();
    try {
      await axios.post("https://localhost:44381/ReceiptMaster/Insert",{
       
      InvoiceNo : InvoiceNo,
       Date: Date,
       Amount : Amount,
       Description: Description,
      });
       console.log(save);
      alert(" Registation Successfully");
          setDate("");
          setAmount("");
          setInvoiceNo("");
          setDescription("");
      Load();
    } catch (err) {
      alert(err);
    }
  }


 
  async function edit(data) {
    setInvoiceNo(data.InvoiceNo);
    setRId(data.RId);
    setDate(data.Date);
    setAmount(data.Amount);
    setDescription(data.Description);
  }

  async function Delete(RId) {
    try {
      await axios.delete("https://localhost:44381/ReceiptMaster/Delete/" + RId);
      alert("Deleted Successfully");
      clearForm();
      Load();
    } catch (error) {
      console.error(error);
      alert("Error: " + error.message);
    }
  }

  async function update(event) {
    event.preventDefault();
    try {
      await axios.patch(
        "https://localhost:44381/ReceiptMaster/Put/" + RId,
        {
          RId: RId,
          Amount: Amount,
          InvoiceNo: InvoiceNo,
          Date: Date,
          Description: Description,
        }
      );
      alert("Payment Detail Updated");
      clearForm();
      Load();
    } catch (error) {
      console.error(error);
      alert("Error: " + error.message);
    }
  }

  const clearForm = () => {
    setRId("");
    setDate("");
    setAmount("");
    setInvoiceNo("");
    setDescription("");
  };

  return (
    <div className="container mt-4">
      <h1 className="chart-heading">PAYMENT VOUCHER</h1>
      <form>
        <div className="form-row">
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
          <div style={{marginLeft:"600px", marginTop:"-115px"}} className="form-group col-md-6">
            <label>Amount</label>
            <input
              type="number"
              className="form-control"
              id="Amount"
              value={Amount}
              onChange={(event) => {
                setAmount(event.target.value);
              }}
            />
          </div>
          <div className="form-group col-md-6">
            <label>InvoiceNo</label>
            <input
              type="text"
              className="form-control"
              id="InvoiceNo"
              value={InvoiceNo}
              onChange={(event) => {
                setInvoiceNo(event.target.value);
              }}
            />
          </div>
          <div style={{marginLeft:"600px", marginTop:"-115px"}} className="form-group col-md-6">
            <label>Description</label>
            <input
              type="text"
              className="form-control"
              id="Description"
              value={Description}
              onChange={(event) => {
                setDescription(event.target.value);
              }}
            />
          </div>
          <div>
            <button className="btn btn-success mt-4" onClick={save}>
              Register
            </button>
            <button className="btn btn-primary mt-4" onClick={update}>
              Update
            </button>
          </div>
        </div>
      </form>
      <br />
      <table style={{borderRadius:"20px"}}  className="table bg-white" align="center">
        <thead className="thead-dark">
          <tr>
            <th scope="col">Invoice No</th>
            <th scope="col">Date</th>
            <th scope="col">Amount</th>
            <th scope="col">Description</th>
            <th scope="col">Option</th>
          </tr>
        </thead>
        <tbody>
          {Payment.map((data) => (
            <tr key={data.RId}>
              <th scope="row"> {data.InvoiceNo}</th>
              <td>{data.Date}</td>
              <td>{data.Amount}</td>
              <td>{data.Description}</td>
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
                  onClick={() => Delete(data.RId)}
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

export default PaymentVoucher;
