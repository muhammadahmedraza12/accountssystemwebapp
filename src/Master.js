import React from "react";
import { variables } from "./Variables";
import { NavLink } from "react-router-dom";
export default class Master extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            MasterAccount: [],
            modalTitle: "",
            MastrAccount: "",
            Status: "",
            id: 0,
            Fid: 1
        }
    }
    addClick() {
        this.setState({
            modalTitle: 'Add MasterAC',
            id: 0,
            MastrAccount: "",
            Status: "",
            Fid: 1
        });
    }
    refrestList() {
        fetch("https://localhost:44381/MasterAC/GetAllMasterAC")
            
            .then(response => response.json())
            .then(data => {
                console.log(data)
                this.setState({ MasterAccount: data });
            });
            
    }
    createClick() {
        fetch("https://localhost:44381/MasterAC/SaveMasterAc", {
            method: "POST",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },

            body: JSON.stringify({
                Fid: this.state.Fid,
                MastrAccount: this.state.MastrAccount,
                Status: this.state.Status,
            })
        })
            .then(res => res.json())
            .then(result => this.refrestList())
            .catch(error => console.log(error))
    }

    componentDidMount() {
        this.refrestList();
    }
    render() {

        const {
            MasterAccount,
            modalTitle,
            id,
            MastrAccount,
            Status,
            Fid
        } = this.state;

        return (
            <>
                <div>
                    <button type='button'
                        className='btn btn-primary m-2 float-end'
                        data-bs-toggle="modal"
                        data-bs-target="#exampleModal"
                        onClick={() => this.addClick()}>
                        Add MasterAc
                    </button>

                    <table className="table table-striped">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>MastrAccount</th>
                                <th>Status</th>
                                <th>Options</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                               MasterAccount.map(data => {
                                    return (
                                        <>
                                            <tr key={data.id}>
                                                <td>{data.id}</td>
                                                <td>{data.MastrAccount}</td>
                                                <td>{data.Status}</td>
                                            </tr>
                                        </>
                                    )

                                })
                            }
                        </tbody>
                    </table>
                    <div className="modal fade" id="exampleModal" tabIndex="-
1" aria-hidden="true">
                        <div className="modal-dialog modal-lg modal-dialogcentered">
                            <div className="modal-content">
                                <div className="modal-header">
                                    <h5 className="modaltitle">{modalTitle}</h5>
                                    <button type="button" className="btnclose" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div className="modal-body">
                                    <div className="input-group mb-3">
                                        <span className="input-grouptext">FixedAccount</span>
                                        <select className="formcontrol" onChange={(e) => { this.setState({ Fid: e.target.value }) }}>
                                            <option value={1}>Monday</option>
                                            <option value={2}>Tuesday</option>
                                            <option value={3}>Wednesday</option>
                                            <option value={4}>Thursday</option>
                                            <option value={5}>Friday</option>
                                            <option value={6}>Saturday</option>
                                            <option value={7}>Sunday</option>
                                        </select>
                                    </div>
                                    <div className="input-group mb-3">
                                        <span className="input-grouptext">Fid</span>
                                        <input type="text" className="formcontrol" value={Fid} onChange={(event) => { this.setState({ Fid: event.target.value }) }} />
                                    </div>
                                    <div className="input-group mb-3">
                                        <span className="input-grouptext">MasterAc</span>
                                        <input type="text" className="formcontrol" value={MastrAccount} onChange={(event) => { this.setState({ MastrAccount: event.target.value }) }} />
                                    </div>
                                    <div className="input-group mb-3">
                                        <span className="input-grouptext">Status</span>
                                        <input type="text" className="formcontrol" value={Status} onChange={(event) => { this.setState({ Status: event.target.value }) }} />
                                    </div>
                                    {id == 0 ?
                                        <button type="button"
                                            className="btn btn-primary float-start"
                                            onClick={() => this.createClick()}
                                        >Create</button>
                                        : null}
                                    {id != 0 ?
                                        <button type="button"
                                            className="btn btn-primary float-start"
                                            onClick={() => this.updateClick()}
                                        >Update</button>
                                        : null}
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </>
        )
    }
}