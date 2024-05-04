import axios from "axios";
import { useEffect, useState } from "react";

function TrailBalan(){
    
    const [TrailBalance, setTrailBalance]= useState([]);


    useEffect(() => {
        (async () => await Load())();
      }, []);

      async function Load() {
    
        const res = await axios.get("https://localhost:44381/TrailB/GetAllTrailBalance");
        setTrailBalance(res.data);  
        console.log(res.data)
      }
return(

      <table class="table table-dark" align="center">
        
      <thead>
        <tr>
          <th scope="col">ACCOUNT NAME</th>
          <th scope="col">Debit  </th>
          <th scope="col">Credit </th>
          <th scope="col"></th>
        </tr>
      </thead>         
      {TrailBalance.map((data)=> {
        return (
          <tbody>
            <tr>
              <th scope="row"> 
              {data.AccountName}</th>
              <td>{data.Debit}</td>
              <td>{data.Credit}</td>
              <td>
             
              </td>
            </tr>
          </tbody>
    );
  })}
</table>
)
}
export default TrailBalan;