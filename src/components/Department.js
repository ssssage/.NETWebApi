import React, { Component } from 'react';
import { Table } from 'react-bootstrap';

export class Department extends Component {
    constructor(props) {
        super(props);
        this.state = { deps: [] }
    }
    componentDidMount() {
        this.refreshList();
    }
    refreshList() {
       fetch('http://localhost:55663/')
        .then(response=> response.json())
        .then(data => {
       this.setState({deps:data});
       }
);
    }
    render() {
        const { deps } = this.state;
        return (
            <Table className="mt-4" striped bordered hover size="sm">
                <thead>
                    <th>DepartmentID</th>
                    <th>DepartmentName</th>
                </thead>
                <tbody>
                    {deps.map(dep =>
                        <tr key={dep.DepartmentID}>
                            <td>{dep.DepartmentID}</td>
                            <td>{dep.DepartmentName}</td>
                        </tr>
                    )}
                </tbody>
            </Table>
        )
    }
}
