import React from "react";
import { variables } from "./Variables";
import { Navigate, useParams } from "react-router-dom";

const withrouter = (WrappedComponet) => {
    return (props) => {
        const routeParams = useParams();
        return <WrappedComponet params={routeParams} />
    }
}


class AddMasterAC extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            users: [],
            MastrAccount: "",
            Status: 1,
            FixedAccount: "",
            id: 1,
            Fid: 1,
            navigate: false
        }
    }
    id = this.props.params.id
    GetUser = () => {
        fetch("https://localhost:44381/MasterAC/GetAllMasterAccount")
            .then(response => response.json())
            .then(result => this.setState({ users: result }))
    }
    GetDataById = (Id) => {
        fetch("https://localhost:44381/MasterAC/MasterAccount_GetById/" + Id)
            .then(response => response.json())
            .then((result) => {
                console.log(result)
                this.setState({ MastrAccount: result.MastrAccount, Status: result.Status, id: result.id, FixedAccount: result.FixedAccount , Fid : result.Fid })
            })
    }
    componentDidMount() {
        this.GetUser()
        if (this.id) {
            this.GetDataById(this.id)
        }
    }
    changetitle = (e) => {
        this.setState({ MastrAccount: e.target.value })
    }
    changebody = (e) => {
        this.setState({ Status: e.target.value })
    }
    changeuser = (e) => {
        this.setState({ FixedAccount: e.target.value })
    }
    changeuser = (e) => {
        this.setState({ Fid: e.target.value })
    }
    submitFormForUpdate = (e) => {
        e.preventDefault();
        fetch("https://localhost:44381/MasterAC/MasterACUpdate/" + this.state.id, {
            method: "Put",
            body: JSON.stringify({
                Status: this.state.Status,
                MastrAccount: this.state.MastrAccount,
                FixedAccount: this.state.FixedAccount,
                Fid : this.state.Fid
            })

        })
            .then(response => response.json())
            .then(result => {
                this.setState({ navigate: true })
            }
            )
            .catch(error => { console.log(error) })
    }
    submitForm = (e) => {
        e.preventDefault()
        fetch("https://localhost:44381/MasterAC/SaveMasterAc", {
            method: "Post",
            body: JSON.stringify({
                Status: this.state.Status,
                MastrAccount: this.state.MastrAccount,
                FixedAccount: this.state.FixedAccount,
                Fid : this.state.Fid
            })

        })
            .then(response => response.json())
            .then(result => {
                this.setState({ navigate: true })
            }
            )
            .catch(error => { console.log(error) })
    }
    render() {
        return (
            <form method="post" onSubmit={!this.id ? this.submitForm : this.submitFormForUpdate}>
                <div className="row">
                    <div className="form-group mb-3">
                        <label htmlFor="FixedAccount">FixedAccount</label>
                        <input id="FixedAccount" className="form-control" required value={this.state.FixedAccount} onChange={this.changeFixedAccount} />
                    </div>
                    <div className="form-group mb-3">
                        <label htmlFor="Status">Status</label>
                        <input id="Status" className="form-control" required value={this.state.Status} onChange={this.changeStatus} />
                    </div>
                    <div className="form-group mb-3">
                        <label htmlFor="title">FixedAccount</label>
                        <select className="form-control" value={this.state.FixedAccount} onChange={this.changeuser}>
                            <option value={0}>--Select User</option>
                            {
                                this.state.users.map(item => {
                                    return (
                                        <option value={item.id} key={item.id}>{item.name}</option>
                                    )
                                })
                            }
                        </select>
                    </div>
                    <div className="form-group mb-3">

                        <button className="btn btn-primary" type="submit"> {this.id ? "Update" : "Create"}</button>


                    </div>
                    {
                        this.state.navigate ?
                            <Navigate to="/MasterAccount" />
                            : <></>
                    }
                </div>
            </form>
        )
    }


}
export default withrouter(AddMasterAC);