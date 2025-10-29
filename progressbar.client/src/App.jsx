import { useState, useEffect } from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import './App.css'
import CallWithProgress from './ProgressBar/ProgressBar'

function App() {

    const extensiveRequestHndlr = (data) => {
        console.log(data.streamed_data)
    }

    const extensiveRequestSubprocessHndlr = (data) => {
        console.log(data.streamed_data)
    }

    const extensiveRequestDataRetrievalHndlr = (data) => {
        console.log(data.streamed_data)
    }

    const extensiveReq = () => {

        CallWithProgress("https://localhost:7259/LonRequestSim/0", extensiveRequestHndlr)

    }

    const extensiveReqWithSubProcess = () => {

        CallWithProgress("https://localhost:7259/LonRequestSim/1", extensiveRequestSubprocessHndlr)

    }

    const extensiveReqWithDataRetrieval = () => {

        CallWithProgress("https://localhost:7259/LonRequestSim/2", extensiveRequestDataRetrievalHndlr)

    }

  return (
      <Container fluid>
          <Row>
              <Col xs={12} className="m-4">
                  <h1>For now, check the console. Modals with actual progress bars will be added</h1>
              </Col>
          </Row>
          <Row>
              <Col xs={12} className="m-4">
                  <Button variant="primary" size="lg" style={{ 'minWidth': '40%' }} onClick={extensiveReq}>Simulate extensive request</Button>
              </Col>
          </Row>
          <Row>
              <Col xs={12} className="m-4">
                  <Button variant="primary" size="lg" style={{ 'minWidth': '40%' }} onClick={extensiveReqWithSubProcess}>Simulate extensive request with sub process</Button>
              </Col>
          </Row>
          <Row>
              <Col xs={12} className="m-4">
                  <Button variant="primary" size="lg" style={{ 'minWidth': '40%' }} onClick={extensiveReqWithDataRetrieval}>Simulate extensive request with data retrieval</Button>
              </Col>
          </Row>
      </Container>
  )
}

export default App
