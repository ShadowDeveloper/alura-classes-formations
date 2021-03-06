import 'package:bytebank/components/progress.dart';
import 'package:bytebank/screens/transaction_form.dart';
import 'package:flutter/material.dart';
import 'package:bytebank/database/dao/contact_dao.dart';
import 'package:bytebank/helper/constants.dart';
import 'package:bytebank/screens/contact_form.dart';
import 'package:bytebank/models/contact.dart';
import 'package:bytebank/screens/contact_item.dart';

class ContactList extends StatefulWidget {
  @override
  _ContactListState createState() => _ContactListState();
}

class _ContactListState extends State<ContactList> {
  final ContactDao _dao = ContactDao();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(ComumConstants().transfer.toUpperCase()),
      ),
      body: Padding(
        padding: EdgeInsets.all(8.0),
        child: FutureBuilder<List<Contact>>(
          // initialData: List(),
          future: _dao.getAllContacts(),
          builder: (context, snapshot) {
            switch (snapshot.connectionState) {
              case ConnectionState.none:
                break;
              case ConnectionState.waiting:
                return Progress(
                  message: "Carregando...",
                );
                break;
              case ConnectionState.active:
                break;
              case ConnectionState.done:
                final List<Contact> _contactList = snapshot.data;
                return ListView.builder(
                  itemCount: _contactList.length,
                  itemBuilder: (context, index) {
                    final Contact contato = _contactList[index];
                    return ContactItem(
                      contato,
                      onClick: () {
                        Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) => TransactionForm(contato),
                          ),
                        );
                      },
                    );
                  },
                );
                break;
            }
            return Text("Unknow error");
          },
        ),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          final Future _navigatorRouter = Navigator.of(context).push(
            MaterialPageRoute(
              builder: (context) => ContactForm(),
            ),
          );
          _navigatorRouter.then(
            (newContact) {
              if (newContact != null) {
                setState(
                  () {
                    _dao.getAllContacts();
                  },
                );
              }
            },
          );
        },
        child: Icon(Icons.add),
        backgroundColor: Theme.of(context).accentColor,
      ),
    );
  }
}
