const express = require('express')
const app = express()
const port = 5000
const sessions = require('./routes/sessions');
const cors = require("cors");

app.use(cors());

app.use(express.urlencoded({
  extended: true
}))
app.use(express.json());

app.get('/sessions', sessions.findAll);
app.get('/sessions/:id', sessions.findById);
app.put('/sessions/:id', sessions.editSession);
app.delete('/sessions/:id', sessions.deleteSession);
app.post('/sessions/add', sessions.addSession);

app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`)
})