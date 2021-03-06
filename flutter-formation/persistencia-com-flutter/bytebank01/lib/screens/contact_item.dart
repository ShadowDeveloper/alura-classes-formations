import 'package:bytebank01/models/contact.dart';
import 'package:flutter/material.dart';

class ContactItem extends StatelessWidget {
  final Contact _contactItem;

  ContactItem(this._contactItem);

  @override
  Widget build(BuildContext context) {
    return Card(
      child: ListTile(
        title: Text(
          _contactItem.name,
          style: TextStyle(
            fontSize: 18.0,
            fontWeight: FontWeight.bold,
          ),
        ),
        subtitle: Text(
          _contactItem.accountNumber.toString(),
          style: TextStyle(
            fontSize: 14.0,
          ),
        ),
      ),
    );
  }
}
